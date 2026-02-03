using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.Services;
using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Prescription;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController(PrescriptionService Service) : ControllerBase
    {
        private readonly PrescriptionService _Service = Service;
        
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
        public async Task<IActionResult> Create([FromBody] PrescriptionRequestDTO entity)
        {
            var result = await _Service.Create(entity);
            return StatusCode(result.Status, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PrescriptionRequestDTO entity)
        {
            var result = await _Service.Update(entity);
            return StatusCode(result.Status, result);
        }
    }
}
