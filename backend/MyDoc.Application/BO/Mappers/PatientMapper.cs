using MyDoc.Application.BO.DTO.Patient;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class PatientMapper
    {
        public PatientDTO ToDTO(Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.id,
                UserId = patient.user_id,
                FullName = patient.full_name,
                BirthDate = patient.birth_date,
                Gender = patient.gender,
                Phone = patient.phone,
                Email = patient.email,
                Address = patient.address,
                IsActive = patient.is_active,
                CreatedAt = patient.created_at,
                UpdatedAt = patient.updated_at
            };
        }

        public PatientTableDTO ToTableDTO(Patient patient)
        {
            return new PatientTableDTO
            {
                Id = patient.id,
                FullName = patient.full_name,
                Phone = patient.phone,
                Email = patient.email,
                IsActive = patient.is_active
            };
        }

        public Patient ToEntity(PatientRequestDTO dto)
        {
            return new Patient
            {
                id = dto.Id ?? 0,
                user_id = dto.UserId,
                full_name = dto.FullName,
                birth_date = dto.BirthDate,
                gender = dto.Gender,
                phone = dto.Phone,
                email = dto.Email,
                address = dto.Address,
                is_active = dto.IsActive ?? true
            };
        }
    }
}