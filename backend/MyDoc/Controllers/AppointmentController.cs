using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Appointment;
using MyDoc.Application.Services;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController(AppointmentService Service) : ControllerBase
    {
        private readonly AppointmentService _Service = Service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _Service.GetAll();
            return StatusCode(result.Status, result);
        }
        [HttpGet("table")]
        public async Task<IActionResult> GetTable()
        {
            try
            {
                var result = await _Service.GetTable();
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred creating appointment: {ex.Message}", 500));
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _Service.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentRequestDTO entity)
        {
            try
            {
                var result = await _Service.Create(entity);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred creating appointment: {ex.Message}", 500));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(AppointmentRequestDTO entity)
        {
            try
            {
                var result = await _Service.Update(entity);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred modyfing clinic: {ex.Message}", 500));
            }
        }
    }
}
