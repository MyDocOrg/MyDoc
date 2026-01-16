using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class MedicationScheduleService
    {
        private readonly MedicationScheduleDAL _dAL;

        public MedicationScheduleService(MedicationScheduleDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<MedicationSchedule>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<MedicationSchedule>>.Ok(result);
        }

        public async Task<ApiResponse<MedicationSchedule?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<MedicationSchedule?>.Ok(result);
        }

        public async Task<ApiResponse<MedicationSchedule>> Create(MedicationSchedule entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<MedicationSchedule>.Ok(result);
        }

        public async Task<ApiResponse<MedicationSchedule>> Update(MedicationSchedule entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<MedicationSchedule>.Ok(result);
        }
    }
}
