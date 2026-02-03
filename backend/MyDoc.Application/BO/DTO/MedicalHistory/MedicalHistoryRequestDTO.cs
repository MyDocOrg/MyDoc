namespace MyDoc.Application.BO.DTO.MedicalHistory
{
    public record MedicalHistoryRequestDTO
    {
        public int? Id { get; init; }
        public int ConsultationId { get; init; }
        public string? Notes { get; init; }
    }
}