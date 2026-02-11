using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.Services;
using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Notification;
using MyDoc.Application.BO.Exceptions;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController(NotificationService Service) : ControllerBase
    {
        private readonly NotificationService _Service = Service;
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _Service.GetAll();
                return StatusCode(result.Status, result);
            }
            catch (BusinessException ex)
            {
                return StatusCode(ex.StatusCode, ApiResponse<string>.Fail(ex.Message, ex.StatusCode));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"Internal server error :{ex.Message}", 500));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _Service.GetById(id);
                return StatusCode(result.Status, result);
            }
            catch (BusinessException ex)
            {
                return StatusCode(ex.StatusCode, ApiResponse<string>.Fail(ex.Message, ex.StatusCode));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"Internal server error :{ex.Message}", 500));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotificationRequestDTO entity)
        {
            try
            {
                var result = await _Service.Create(entity);
                return StatusCode(result.Status, result);
            }
            catch (BusinessException ex)
            {
                return StatusCode(ex.StatusCode, ApiResponse<string>.Fail(ex.Message, ex.StatusCode));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"Internal server error :{ex.Message}", 500));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NotificationRequestDTO entity)
        {
            try
            {
                var result = await _Service.Update(entity);
                return StatusCode(result.Status, result);
            }
            catch (BusinessException ex)
            {
                return StatusCode(ex.StatusCode, ApiResponse<string>.Fail(ex.Message, ex.StatusCode));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"Internal server error :{ex.Message}", 500));
            }
        }
    }
}
