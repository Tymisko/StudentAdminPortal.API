using System.Collections.Generic;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
    }
}
