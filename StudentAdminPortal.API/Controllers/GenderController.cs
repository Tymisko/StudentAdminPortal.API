using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class GenderController : Controller
    {
        private IStudentRepository _studentRepository;
        private IMapper _mapper;

        public GenderController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await _studentRepository.GetGendersAsync();

            if (genderList == null || genderList.Any() == false)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<Gender>>(genderList));
        }
    }
}
