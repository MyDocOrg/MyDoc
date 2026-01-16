using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class DoctorService
    {
        private readonly DoctorDAL _dAL;

        public DoctorService(DoctorDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<Doctor>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Doctor>>.Ok(result);
        }

        public async Task<ApiResponse<Doctor?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Doctor?>.Ok(result);
        }

        public async Task<ApiResponse<Doctor>> Create(Doctor entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<Doctor>.Ok(result);
        }

        public async Task<ApiResponse<Doctor>> Update(Doctor entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Doctor>.Ok(result);
        }
    }
}
