namespace MyDoc.Application.BO.DTO.Doctor
{
    public record DoctorTableDTO
    {
        public int Id { get; init; }
        public string? FullName { get; init; }
        public string? Specialty { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }
        public bool IsActive { get; init; }
    }
}