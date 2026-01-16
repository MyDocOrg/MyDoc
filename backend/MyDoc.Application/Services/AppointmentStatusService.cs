using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class AppointmentStatusService
    {
        private readonly AppointmentStatusDAL _dAL;

        public AppointmentStatusService(AppointmentStatusDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<AppointmentStatus>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<AppointmentStatus>>.Ok(result);
        }

        public async Task<ApiResponse<AppointmentStatus?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<AppointmentStatus?>.Ok(result);
        }

        public async Task<ApiResponse<AppointmentStatus>> Create(AppointmentStatus entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<AppointmentStatus>.Ok(result);
        }

        public async Task<ApiResponse<AppointmentStatus>> Update(AppointmentStatus entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<AppointmentStatus>.Ok(result);
        }
    }
}
