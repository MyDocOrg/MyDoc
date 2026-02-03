namespace MyDoc.Application.BO.DTO.Medicine
{
    public record MedicineTableDTO
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Presentation { get; init; }
        public bool IsActive { get; init; }
    }
}