using MyDoc.Application.BO.DTO.Medicine;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class MedicineMapper
    {
        public MedicineDTO ToDTO(Medicine m)
        {
            return new MedicineDTO
            {
                Id = m.id,
                Name = m.name,
                Description = m.description,
                Presentation = m.presentation,
                IsActive = m.is_active
            };
        }

        public MedicineTableDTO ToTableDTO(Medicine m)
        {
            return new MedicineTableDTO
            {
                Id = m.id,
                Name = m.name,
                Presentation = m.presentation,
                IsActive = m.is_active
            };
        }

        public Medicine ToEntity(MedicineRequestDTO dto)
        {
            return new Medicine
            {
                id = dto.Id ?? 0,
                name = dto.Name,
                description = dto.Description,
                presentation = dto.Presentation,
                is_active = dto.IsActive ?? true
            };
        }
    }
}