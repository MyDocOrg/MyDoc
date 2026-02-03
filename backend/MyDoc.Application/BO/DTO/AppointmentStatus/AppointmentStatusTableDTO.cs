namespace MyDoc.Application.BO.DTO.AppointmentStatus
{
    public record AppointmentStatusTableDTO
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public bool IsActive { get; init; }
    }
}