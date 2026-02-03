using MyDoc.Application.BO.DTO.Consultation;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class ConsultationMapper
    {
        public ConsultationDTO ToDTO(Consultation c)
        {
            return new ConsultationDTO
            {
                Id = c.id,
                AppointmentId = c.appointment_id,
                Reason = c.reason,
                Diagnosis = c.diagnosis,
                ConsultationDate = c.consultation_date,
                WeightKg = c.weight_kg,
                HeightCm = c.height_cm
            };
        }

        public Consultation ToEntity(ConsultationRequestDTO dto)
        {
            return new Consultation
            {
                id = dto.Id ?? 0,
                appointment_id = dto.AppointmentId,
                reason = dto.Reason,
                diagnosis = dto.Diagnosis,
                consultation_date = dto.ConsultationDate,
                weight_kg = dto.WeightKg,
                height_cm = dto.HeightCm
            };
        }
    }
}