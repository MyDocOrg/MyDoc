using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.Services;
using MyDoc.Application.BO.Contants;
using MyDoc.Infrastructure.Models;

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
            var result = await _Service.GetAll();
            return StatusCode(result.Status, result);
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _Service.GetById(id);
            return StatusCode(result.Status, result);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient entity)
        {
            var result = await _Service.Create(entity);
            return StatusCode(result.Status, result);
        }

        // PUT api/<PatientController>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Patient entity)
        {
            var result = await _Service.Update(entity);
            return StatusCode(result.Status, result);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Service.Delete(id);
            return StatusCode(result.Status, result);
        }
    }
}
