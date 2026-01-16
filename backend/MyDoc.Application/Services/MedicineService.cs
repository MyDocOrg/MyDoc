using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class MedicineService
    {
        private readonly MedicineDAL _dAL;

        public MedicineService(MedicineDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<Medicine>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Medicine>>.Ok(result);
        }

        public async Task<ApiResponse<Medicine?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Medicine?>.Ok(result);
        }

        public async Task<ApiResponse<Medicine>> Create(Medicine entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<Medicine>.Ok(result);
        }

        public async Task<ApiResponse<Medicine>> Update(Medicine entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Medicine>.Ok(result);
        }
    }
}
