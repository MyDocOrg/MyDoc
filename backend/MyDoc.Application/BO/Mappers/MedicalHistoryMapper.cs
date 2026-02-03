using MyDoc.Application.BO.DTO.MedicalHistory;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class MedicalHistoryMapper
    {
        public MedicalHistoryDTO ToDTO(MedicalHistory mh)
        {
            return new MedicalHistoryDTO
            {
                Id = mh.id,
                ConsultationId = mh.consultation_id,
                Notes = mh.notes,
                CreatedAt = mh.created_at
            };
        }

        public MedicalHistory ToEntity(MedicalHistoryRequestDTO dto)
        {
            return new MedicalHistory
            {
                id = dto.Id ?? 0,
                consultation_id = dto.ConsultationId,
                notes = dto.Notes,
                created_at = System.DateTime.UtcNow
            };
        }
    }
}