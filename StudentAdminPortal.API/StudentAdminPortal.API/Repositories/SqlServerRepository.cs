using System;
using System.Collections.Generic;
using System.Linq;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlServerRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;

        public SqlServerRepository(StudentAdminContext context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            return _context.Student.ToList();
        }
    }
}
