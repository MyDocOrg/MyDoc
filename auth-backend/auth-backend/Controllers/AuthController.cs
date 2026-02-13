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
            var result = await _service.Login(request, _provider.GetApplicationName());
            return StatusCode(result.Status, result);
        }

        [HttpPost("MyDoc/Register/Doctor")]
        public async Task<IActionResult> MyDocRegister(AuthRegisterDoctorRequest request)
        {
            // Asignar valores por defecto si vienen como 0
            if (request.RoleId == 0) request.RoleId = 2;
            if (request.ApplicationId == 0) request.ApplicationId = 1;
            if (request.SuscriptionId == 0) request.SuscriptionId = 1;

            var result = await _service.RegisterDoctorMyDoc(request);
            return StatusCode(result.Status, result);
        }

        [HttpPost("MyDoc/Register/Patient")]
        public async Task<IActionResult> MyDocPatient(AuthRegisterPatientRequest request)
        {
            // Asignar valores por defecto si vienen como 0
            if (request.RoleId == 0) request.RoleId = 3;
            if (request.ApplicationId == 0) request.ApplicationId = 1;
            if (request.SuscriptionId == 0) request.SuscriptionId = 1;

            var result = await _service.RegisterPatientMyDoc(request);
            return StatusCode(result.Status, result);
        }

        // [HttpPost("MyDoc/User")]
        // public async Task<IActionResult> MyDocUser(AuthUserRequest request)
        // {
        //     var result = await _service.RegisterUserMyDoc(request);
        //     return StatusCode(result.Status, result);
        // }

        [HttpPost("MyVet/Register/Vet")]
        public async Task<IActionResult> MyVetRegister(AuthRegisterVeterinarianRequest request)
        {
            // Asignar valores por defecto si vienen como 0
            if (request.RoleId == 0) request.RoleId = 5;
            if (request.ApplicationId == 0) request.ApplicationId = 2;
            if (request.SuscriptionId == 0) request.SuscriptionId = 1;

            var result = await _service.RegisterVeterinarianMyVet(request);
            return StatusCode(result.Status, result);
        }

        [HttpPost("MyVet/Register/Owner")]
        public async Task<IActionResult> MyVetOwnerRegister(AuthRegisterOwnerRequest request)
        {
            // Asignar valores por defecto si vienen como 0
            if (request.RoleId == 0) request.RoleId = 6;
            if (request.ApplicationId == 0) request.ApplicationId = 2;
            if (request.SuscriptionId == 0) request.SuscriptionId = 1;

            var result = await _service.RegisterOwnerMyVet(request);
            return StatusCode(result.Status, result);
        }
    }
}
