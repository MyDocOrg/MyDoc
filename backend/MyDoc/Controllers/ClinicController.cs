using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Clinic;
using MyDoc.Application.Services;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController(ClinicService Service) : ControllerBase
    {
        private readonly ClinicService _Service = Service;

        [HttpGet("Table")]
        public async Task<IActionResult> GetTable()
        {
            try
            {

                var result = await _Service.GetAll();
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred getting clinics: {ex.Message}", 500));
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _Service.GetAll();
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred getting clinics: {ex.Message}", 500));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _Service.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClinicRequestDTO entity)
        {
            try
            {
                var result = await _Service.Create(entity);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred creating clinic: {ex.Message}", 500));
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Clinic entity)
        {
            var result = await _Service.Update(entity);
            return StatusCode(result.Status, result);
        }
    }
}
