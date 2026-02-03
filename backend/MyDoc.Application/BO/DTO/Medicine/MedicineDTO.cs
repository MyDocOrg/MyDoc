namespace MyDoc.Application.BO.DTO.Medicine
{
    public record MedicineDTO
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? Presentation { get; init; }
        public bool IsActive { get; init; }
    }
}