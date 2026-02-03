using MyDoc.Application.BO.DTO.AppointmentStatus;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class AppointmentStatusMapper
    {
        public AppointmentStatusDTO ToDTO(AppointmentStatus s)
        {
            return new AppointmentStatusDTO
            {
                Id = s.id,
                Name = s.name,
                Description = s.description,
                IsActive = s.is_active
            };
        }

        public AppointmentStatusTableDTO ToTableDTO(AppointmentStatus s)
        {
            return new AppointmentStatusTableDTO
            {
                Id = s.id,
                Name = s.name,
                IsActive = s.is_active
            };
        }

        public AppointmentStatus ToEntity(AppointmentStatusRequestDTO dto)
        {
            return new AppointmentStatus
            {
                id = dto.Id ?? 0,
                name = dto.Name,
                description = dto.Description,
                is_active = dto.IsActive ?? true
            };
        }
    }
}