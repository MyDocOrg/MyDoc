namespace MyDoc.Application.BO.DTO.AppointmentStatus
{
    public record AppointmentStatusRequestDTO
    {
        public int? Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public bool? IsActive { get; init; }
    }
}