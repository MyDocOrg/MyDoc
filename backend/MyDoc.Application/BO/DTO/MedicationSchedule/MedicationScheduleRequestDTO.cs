namespace MyDoc.Application.BO.DTO.MedicationSchedule
{
    public record MedicationScheduleRequestDTO
    {
        public int? Id { get; init; }
        public int PrescriptionId { get; init; }
        public int MedicineId { get; init; }
        public DateOnly? ScheduledDate { get; init; }
        public TimeOnly? ScheduledTime { get; init; }
        public bool? Taken { get; init; }
    }
}