using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gender = StudentAdminPortal.API.DataModels.Gender;
using Student = StudentAdminPortal.API.DataModels.Student;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<List<Gender>> GetGendersAsync();

        Task<bool> ExistsAsync(Guid studentId);

        Task<Student> UpdateStudent(Guid studentId, Student request);

        Task<Student> DeleteStudent(Guid studentId);

        Task<Student> AddStudent(Student request);
        
        Task<bool> UpdateProfileImageAsync(Guid studentId,  string profileImageUrl);
    }
}
