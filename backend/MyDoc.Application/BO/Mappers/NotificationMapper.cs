using MyDoc.Application.BO.DTO.Notification;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class NotificationMapper
    {
        public NotificationDTO ToDTO(Notification n)
        {
            return new NotificationDTO
            {
                Id = n.id,
                MedicationScheduleId = n.medication_schedule_id,
                SentAt = n.sent_at,
                IsSent = n.is_sent
            };
        }

        public Notification ToEntity(NotificationRequestDTO dto)
        {
            return new Notification
            {
                id = dto.Id ?? 0,
                medication_schedule_id = dto.MedicationScheduleId,
                sent_at = dto.SentAt,
                is_sent = dto.IsSent ?? false
            };
        }
    }
}