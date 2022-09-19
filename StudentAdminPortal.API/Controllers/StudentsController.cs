using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetStudentsAsync();

            return Ok(_mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("{studentId:guid}"), ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await _studentRepository.GetStudentAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Student>(student));
        }

        [HttpPut]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if (await _studentRepository.ExistsAsync(studentId))
            {
                // Update details
                var updatedStudent = await _studentRepository.UpdateStudent(studentId, _mapper.Map<DataModels.Student>(request));
                if (updatedStudent != null)
                {
                    return Ok(_mapper.Map<Student>(updatedStudent));
                }
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await _studentRepository.ExistsAsync(studentId))
            {
                var student = await _studentRepository.DeleteStudent(studentId);
                return Ok(_mapper.Map<Student>(student));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            var mappedRequest = _mapper.Map<DataModels.Student>(request);
            var student = await _studentRepository.AddStudent(mappedRequest);
            return CreatedAtAction(nameof(GetStudentAsync), new {studentId = student.Id}, _mapper.Map<Student>(student));
        }
    }
}