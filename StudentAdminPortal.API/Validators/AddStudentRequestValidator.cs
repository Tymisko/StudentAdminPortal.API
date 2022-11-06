using System.Linq;
using FluentValidation;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Validators
{
	public class AddStudentRequestValidator : AbstractValidator<AddStudentRequest>
	{
		public AddStudentRequestValidator(IStudentRepository studentRepository)
		{
			RuleFor(x => x.FirstName).NotEmpty();
			RuleFor(x => x.LastName).NotEmpty();
			RuleFor(x => x.DateOfBirth).NotEmpty();
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
			RuleFor(x => x.Mobile).GreaterThan(12345678).LessThan(1234567890);
			RuleFor(x => x.GenderId).NotEmpty().Must(id =>
			{
				var gender = studentRepository.GetGendersAsync().Result.ToList().FirstOrDefault(g => g.Id == id);
				return gender != null;
			}).WithMessage("Please select a valid gender");
			RuleFor(x => x.PhysicalAddress).NotEmpty();
			RuleFor(x => x.PostalAddress).NotEmpty();
		}
	}
}