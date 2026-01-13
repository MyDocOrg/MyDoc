using MyDoc.Models;
using MyDoc.UseCase.Abstract;

namespace MyDoc.UseCase
{
    public class UserUseCase : AbstractUseCase<Paciente>
    {
        public UserUseCase(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<Paciente>> GetAllUsers()
        {
            return (await GetAllAsync()).ToList();
        }
    }
}
