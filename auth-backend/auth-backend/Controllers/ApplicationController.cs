using auth_backend.DTO.Contants;
using auth_backend.Exceptions;
using auth_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auth_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController(ApplicationService service) : ControllerBase
    {
        private readonly ApplicationService _service = service;
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var result = await _service.GetById(id);
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
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {

                var result = await _service.GetList();
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
