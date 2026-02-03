namespace MyDoc.Application.BO.DTO.ClinicDoctor
{
    public record ClinicDoctorDTO
    {
        public int Id { get; init; }
        public int DoctorId { get; init; }
        public int ClinicId { get; init; }
        public bool IsActive { get; init; }
    }
}