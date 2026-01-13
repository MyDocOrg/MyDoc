using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.UseCase;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserUseCase useCase) : ControllerBase
    {
        private readonly UserUseCase _useCase = useCase;
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _useCase.GetAllUsers();
            return Ok(users);
        }
    }
}
