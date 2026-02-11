using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Appointment;
using MyDoc.Application.DAL;
using MyDoc.Application.Helper;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class AppointmentService(CurrentUserHelper currentUserHelper, AppointmentDAL dAL)
    {
        private readonly AppointmentDAL _dAL = dAL;
        private readonly CurrentUserHelper _currentUserHelper = currentUserHelper;

        public async Task<ApiResponse<List<AppointmentTableDTO>>> GetTable()
        {
            var result = await _dAL.GetTable();
            return ApiResponse<List<AppointmentTableDTO>>.Ok(result);
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

        public async Task<ApiResponse<Appointment>> Create(AppointmentRequestDTO entity)
        {
            var result = await _dAL.Create(new Appointment
            {
                patient_id = _currentUserHelper.PatientId ?? 0,
                doctor_id = entity.DoctorId,
                clinic_id = entity.ClinicId,
                status_id = entity.StatusId,
                appointment_date = entity.AppointmentDate,
                created_at = System.DateTime.UtcNow
            });
            return ApiResponse<Appointment>.Ok(result);
        }
        public async Task<ApiResponse<Appointment>> Update(AppointmentRequestDTO entity)
        {
            var result = await _dAL.Update(new Appointment
            {
                id = entity.Id,
                patient_id = _currentUserHelper.PatientId ?? 0,
                doctor_id = entity.DoctorId,
                clinic_id = entity.ClinicId,
                status_id = entity.StatusId,
                appointment_date = entity.AppointmentDate
            });
            return ApiResponse<Appointment>.Ok(result);
        }
    }
}
