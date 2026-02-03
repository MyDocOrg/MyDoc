namespace MyDoc.Application.BO.DTO.ClinicDoctor
{
    public record ClinicDoctorRequestDTO
    {
        public int? Id { get; init; }
        public int DoctorId { get; init; }
        public int ClinicId { get; init; }
        public bool? IsActive { get; init; }
    }
}