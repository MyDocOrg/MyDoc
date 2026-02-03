namespace MyDoc.Application.BO.DTO.Notification
{
    public record NotificationRequestDTO
    {
        public int? Id { get; init; }
        public int MedicationScheduleId { get; init; }
        public DateTime? SentAt { get; init; }
        public bool? IsSent { get; init; }
    }
}