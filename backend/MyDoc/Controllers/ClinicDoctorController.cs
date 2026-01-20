using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.Services;
using MyDoc.Application.BO.Contants;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicDoctorController(ClinicDoctorService Service) : ControllerBase
    {
        private readonly ClinicDoctorService _Service = Service;
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _Service.GetAll();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _Service.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClinicDoctor entity)
        {
            var result = await _Service.Create(entity);
            return StatusCode(result.Status, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClinicDoctor entity)
        {
            var result = await _Service.Update(entity);
            return StatusCode(result.Status, result);
        }
    }
}
