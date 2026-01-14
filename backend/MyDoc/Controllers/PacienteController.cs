using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.BL;
using MyDoc.Application.BO.Contants;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController(PacienteBL bL) : ControllerBase
    {
        private readonly PacienteBL _bL = bL;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _bL.GetAll();
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"An unexpected error occurred obtain module: {ex.Message}", 500));
            }
        }
    }
}
