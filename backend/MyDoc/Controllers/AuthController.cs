using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Auth;
using MyDoc.Application.Services;
using MyDoc.Middleware;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AuthService service, ApplicationProvider provider) : ControllerBase
    {
        private readonly AuthService _service = service;
        private readonly ApplicationProvider _provider = provider;
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginRequest request)
        {
            try
            {
                
                var result = await _service.Login(request, _provider.GetApplicationName());
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred during login: {ex.Message}", 500));
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(AuthRegisterRequest request)
        {
            try
            {

                var result = await _service.Register(request, _provider.GetApplicationName());
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred during login: {ex.Message}", 500));
            }
        }
    }
}
