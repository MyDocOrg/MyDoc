namespace MyDoc.Application.BO.DTO.MedicalHistory
{
    public record MedicalHistoryDTO
    {
        public int Id { get; init; }
        public int ConsultationId { get; init; }
        public string? Notes { get; init; }
        public DateTime? CreatedAt { get; init; }
    }
}