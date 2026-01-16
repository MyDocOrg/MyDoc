using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class ConsultationService
    {
        private readonly ConsultationDAL _dAL;

        public ConsultationService(ConsultationDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<Consultation>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Consultation>>.Ok(result);
        }

        public async Task<ApiResponse<Consultation?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Consultation?>.Ok(result);
        }

        public async Task<ApiResponse<Consultation>> Create(Consultation entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<Consultation>.Ok(result);
        }

        public async Task<ApiResponse<Consultation>> Update(Consultation entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Consultation>.Ok(result);
        }
    }
}
