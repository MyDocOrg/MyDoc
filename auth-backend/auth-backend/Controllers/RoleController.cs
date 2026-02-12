using auth_backend.DTO.Contants;
using auth_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace auth_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(RoleService service) : ControllerBase
    {
        private readonly RoleService _service = service;

        [HttpGet("MyDoc")]
        public async Task<IActionResult> GetByMyDoc()
        {
            var result = await _service.GetByMyDoc();
            return StatusCode(result.Status, result);
        }

        [HttpGet("MyVet")]
        public async Task<IActionResult> GetByMyVet()
        {
            var result = await _service.GetByMyVet();
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
