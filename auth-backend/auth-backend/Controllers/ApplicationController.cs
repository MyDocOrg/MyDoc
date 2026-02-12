using auth_backend.DTO.Contants;
using auth_backend.Services;
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
            var result = await _service.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _service.GetList();
            return StatusCode(result.Status, result);
        }
    }
}
