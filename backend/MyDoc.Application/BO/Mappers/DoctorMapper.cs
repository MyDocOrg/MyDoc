using MyDoc.Application.BO.DTO.Doctor;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class DoctorMapper
    {
        public DoctorDTO ToDTO(Doctor doctor)
        {
            return new DoctorDTO
            {
                Id = doctor.id,
                UserId = doctor.user_id,
                FullName = doctor.full_name,
                Specialty = doctor.specialty,
                ProfessionalLicense = doctor.professional_license,
                Phone = doctor.phone,
                Email = doctor.email,
                IsActive = doctor.is_active,
                CreatedAt = doctor.created_at,
                UpdatedAt = doctor.updated_at
            };
        }

        public DoctorTableDTO ToDoctorTableDTO(Doctor doctor)
        {
            return new DoctorTableDTO
            {
                Id = doctor.id,
                FullName = doctor.full_name,
                Specialty = doctor.specialty,
                Phone = doctor.phone,
                Email = doctor.email,
                IsActive = doctor.is_active
            };
        }

        public Doctor ToEntity(DoctorRequestDTO dto)
        {
            return new Doctor
            {
                id = dto.Id ?? 0,
                user_id = dto.UserId,
                full_name = dto.FullName,
                specialty = dto.Specialty,
                professional_license = dto.ProfessionalLicense,
                phone = dto.Phone,
                email = dto.Email,
                is_active = dto.IsActive ?? true
            };
        }
    }
}