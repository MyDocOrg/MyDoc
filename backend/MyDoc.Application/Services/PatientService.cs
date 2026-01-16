using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class PatientService
    {
        private readonly PatientDAL _dAL;

        public PatientService(PatientDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<Patient>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Patient>>.Ok(result);
        }

        public async Task<ApiResponse<Patient?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Patient?>.Ok(result);
        }

        public async Task<ApiResponse<Patient>> Create(Patient entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<Patient>.Ok(result);
        }

        public async Task<ApiResponse<Patient>> Update(Patient entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Patient>.Ok(result);
        }
    }
}
