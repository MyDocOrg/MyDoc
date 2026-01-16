using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class PrescriptionService
    {
        private readonly PrescriptionDAL _dAL;

        public PrescriptionService(PrescriptionDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<Prescription>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Prescription>>.Ok(result);
        }

        public async Task<ApiResponse<Prescription?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Prescription?>.Ok(result);
        }

        public async Task<ApiResponse<Prescription>> Create(Prescription entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<Prescription>.Ok(result);
        }

        public async Task<ApiResponse<Prescription>> Update(Prescription entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Prescription>.Ok(result);
        }
    }
}
