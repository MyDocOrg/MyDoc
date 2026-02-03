namespace MyDoc.Application.BO.DTO.Patient
{
    public record PatientRequestDTO
    {
        public int? Id { get; init; }
        public int? UserId { get; init; }
        public string? FullName { get; init; }
        public DateOnly? BirthDate { get; init; }
        public string? Gender { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }
        public string? Address { get; init; }
        public bool? IsActive { get; init; }
    }
}