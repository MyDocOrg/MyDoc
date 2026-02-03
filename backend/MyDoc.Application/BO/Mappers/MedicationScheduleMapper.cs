using MyDoc.Application.BO.DTO.MedicationSchedule;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class MedicationScheduleMapper
    {
        public MedicationScheduleDTO ToDTO(MedicationSchedule ms)
        {
            return new MedicationScheduleDTO
            {
                Id = ms.id,
                PrescriptionId = ms.prescription_id,
                MedicineId = ms.medicine_id,
                ScheduledDate = ms.scheduled_date,
                ScheduledTime = ms.scheduled_time,
                Taken = ms.taken
            };
        }

        public MedicationSchedule ToEntity(MedicationScheduleRequestDTO dto)
        {
            return new MedicationSchedule
            {
                id = dto.Id ?? 0,
                prescription_id = dto.PrescriptionId,
                medicine_id = dto.MedicineId,
                scheduled_date = dto.ScheduledDate,
                scheduled_time = dto.ScheduledTime,
                taken = dto.Taken
            };
        }
    }
}