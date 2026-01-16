using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class ClinicService
    {
        private readonly ClinicDAL _dAL;

        public ClinicService(ClinicDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<Clinic>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Clinic>>.Ok(result);
        }

        public async Task<ApiResponse<Clinic?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Clinic?>.Ok(result);
        }

        public async Task<ApiResponse<Clinic>> Create(Clinic entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<Clinic>.Ok(result);
        }

        public async Task<ApiResponse<Clinic>> Update(Clinic entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Clinic>.Ok(result);
        }
    }
}
