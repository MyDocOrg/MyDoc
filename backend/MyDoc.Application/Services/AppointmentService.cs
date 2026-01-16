using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class AppointmentService
    {
        private readonly AppointmentDAL _dAL;

        public AppointmentService(AppointmentDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<Appointment>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Appointment>>.Ok(result);
        }

        public async Task<ApiResponse<Appointment?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Appointment?>.Ok(result);
        }

        public async Task<ApiResponse<Appointment>> Create(Appointment entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<Appointment>.Ok(result);
        }

        public async Task<ApiResponse<Appointment>> Update(Appointment entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Appointment>.Ok(result);
        }
    }
}
