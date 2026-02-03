namespace MyDoc.Application.BO.DTO.Patient
{
    public record PatientTableDTO
    {
        public int Id { get; init; }
        public string? FullName { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }
        public bool IsActive { get; init; }
    }
}