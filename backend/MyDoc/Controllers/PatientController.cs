using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.Services;
using MyDoc.Application.BO.Contants;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(PatientService patientService) : ControllerBase
    {
        private readonly PatientService _patientService = patientService;
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _patientService.GetAll();
            return StatusCode(result.Status, result);
        }
    }
}
