using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class ClinicDoctorService
    {
        private readonly ClinicDoctorDAL _dAL;

        public ClinicDoctorService(ClinicDoctorDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<ClinicDoctor>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<ClinicDoctor>>.Ok(result);
        }

        public async Task<ApiResponse<ClinicDoctor?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<ClinicDoctor?>.Ok(result);
        }

        public async Task<ApiResponse<ClinicDoctor>> Create(ClinicDoctor entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<ClinicDoctor>.Ok(result);
        }

        public async Task<ApiResponse<ClinicDoctor>> Update(ClinicDoctor entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<ClinicDoctor>.Ok(result);
        }
    }
}
