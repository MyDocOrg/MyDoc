namespace MyDoc.Application.BO.DTO.PrescriptionMedicine
{
    public record PrescriptionMedicineRequestDTO
    {
        public int? Id { get; init; }
        public int PrescriptionId { get; init; }
        public int MedicineId { get; init; }
        public string? Dosage { get; init; }
        public string? Frequency { get; init; }
        public string? Duration { get; init; }
    }
}