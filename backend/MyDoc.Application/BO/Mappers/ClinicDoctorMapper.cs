using MyDoc.Application.BO.DTO.ClinicDoctor;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class ClinicDoctorMapper
    {
        public ClinicDoctorDTO ToDTO(ClinicDoctor c)
        {
            return new ClinicDoctorDTO
            {
                Id = c.id,
                DoctorId = c.doctor_id,
                ClinicId = c.clinic_id,
                IsActive = c.is_active
            };
        }

        public ClinicDoctorTableDTO ToTableDTO(ClinicDoctor c)
        {
            return new ClinicDoctorTableDTO
            {
                Id = c.id,
                DoctorId = c.doctor_id,
                ClinicId = c.clinic_id,
                IsActive = c.is_active
            };
        }

        public ClinicDoctor ToEntity(ClinicDoctorRequestDTO dto)
        {
            return new ClinicDoctor
            {
                id = dto.Id ?? 0,
                doctor_id = dto.DoctorId,
                clinic_id = dto.ClinicId,
                is_active = dto.IsActive ?? true
            };
        }
    }
}