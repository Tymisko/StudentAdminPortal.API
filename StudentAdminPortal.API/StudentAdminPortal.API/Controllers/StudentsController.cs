using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllStudents()
        {
            var students = _studentRepository.GetStudents();

            var domainModelStudents = new List<Student>();

            foreach (var student in students)
            {
                domainModelStudents.Add(new Student
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImageUrl = student.ProfileImageUrl,
                    GenderId = student.GenderId,
                    Address = new Address
                    {
                        Id = student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress = student.Address.PostalAddress,
                    },
                    Gender = new Gender
                    {
                        Id = student.Gender.Id,
                        Description = student.Gender.Description
                    }
                });
            }

            return Ok(domainModelStudents);
        }
    }
}
