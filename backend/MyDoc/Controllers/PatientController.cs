using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.Services;
using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Patient;
using MyDoc.Application.BO.Exceptions;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(PatientService Service) : ControllerBase
    {
        private readonly PatientService _Service = Service;

        //Trigger CD test just ignore this line
        // GET: api/<PatientController>
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

        // GET api/<PatientController>/5
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

        // POST api/<PatientController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientRequestDTO entity)
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

        // PUT api/<PatientController>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PatientRequestDTO entity)
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

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _Service.Delete(id);
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
