using auth_backend.DTO.Auth;
using auth_backend.DTO.Contants;
using auth_backend.Provider;
using auth_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace auth_backend.Controllers
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
        [HttpPost("MyDoc/Register/Doctor")]
        public async Task<IActionResult> MyDocRegister(AuthRegisterDoctorRequest request)
        {
            try
            {
                var result = await _service.RegisterDoctorMyDoc(request);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred during login: {ex.Message}", 500));
            }
        }
        [HttpPost("MyDoc/Register/Patient")]
        public async Task<IActionResult> MyDocPatient(AuthRegisterPatientRequest request)
        {
            try
            {

                var result = await _service.RegisterPatientMyDoc(request);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred during login: {ex.Message}", 500));
            }
        }
        [HttpPost("MyVet/Register/Vet")]
        public async Task<IActionResult> MyVetRegister(AuthRegisterVeterinarianRequest request)
        {
            try
            {

                var result = await _service.RegisterVeterinarianMyVet(request);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred during login: {ex.Message}", 500));
            }
        }
        [HttpPost("MyVet/Register/Owner")]
        public async Task<IActionResult> MyVetOwnerRegister(AuthRegisterOwnerRequest request)
        {
            try
            {

                var result = await _service.RegisterOwnerMyVet(request);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred during login: {ex.Message}", 500));
            }
        }
    }
}
