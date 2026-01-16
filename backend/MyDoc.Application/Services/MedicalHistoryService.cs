using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class MedicalHistoryService
    {
        private readonly MedicalHistoryDAL _dAL;

        public MedicalHistoryService(MedicalHistoryDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<MedicalHistory>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<MedicalHistory>>.Ok(result);
        }

        public async Task<ApiResponse<MedicalHistory?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<MedicalHistory?>.Ok(result);
        }

        public async Task<ApiResponse<MedicalHistory>> Create(MedicalHistory entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<MedicalHistory>.Ok(result);
        }

        public async Task<ApiResponse<MedicalHistory>> Update(MedicalHistory entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<MedicalHistory>.Ok(result);
        }
    }
}
