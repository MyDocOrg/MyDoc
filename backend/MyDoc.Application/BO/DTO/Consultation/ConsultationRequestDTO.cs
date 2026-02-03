namespace MyDoc.Application.BO.DTO.Consultation
{
    public record ConsultationRequestDTO
    {
        public int? Id { get; init; }
        public int AppointmentId { get; init; }
        public string? Reason { get; init; }
        public string? Diagnosis { get; init; }
        public DateTime? ConsultationDate { get; init; }
        public decimal? WeightKg { get; init; }
        public decimal? HeightCm { get; init; }
    }
}