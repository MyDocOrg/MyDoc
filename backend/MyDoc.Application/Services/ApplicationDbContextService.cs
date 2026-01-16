using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class ApplicationDbContextService
    {
        private readonly ApplicationDbContextDAL _dAL;

        public ApplicationDbContextService(ApplicationDbContextDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<ApplicationDbContext>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<ApplicationDbContext>>.Ok(result);
        }

        public async Task<ApiResponse<ApplicationDbContext?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<ApplicationDbContext?>.Ok(result);
        }

        public async Task<ApiResponse<ApplicationDbContext>> Create(ApplicationDbContext entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<ApplicationDbContext>.Ok(result);
        }

        public async Task<ApiResponse<ApplicationDbContext>> Update(ApplicationDbContext entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<ApplicationDbContext>.Ok(result);
        }
    }
}
