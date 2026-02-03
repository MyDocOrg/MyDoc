using MyDoc.Application.BO.DTO.PrescriptionMedicine;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Application.BO.Mappers
{
    public class PrescriptionMedicineMapper
    {
        public PrescriptionMedicineDTO ToDTO(PrescriptionMedicine pm)
        {
            return new PrescriptionMedicineDTO
            {
                Id = pm.id,
                PrescriptionId = pm.prescription_id,
                MedicineId = pm.medicine_id,
                Dosage = pm.dosage,
                Frequency = pm.frequency,
                Duration = pm.duration
            };
        }

        public PrescriptionMedicine ToEntity(PrescriptionMedicineRequestDTO dto)
        {
            return new PrescriptionMedicine
            {
                id = dto.Id ?? 0,
                prescription_id = dto.PrescriptionId,
                medicine_id = dto.MedicineId,
                dosage = dto.Dosage,
                frequency = dto.Frequency,
                duration = dto.Duration
            };
        }
    }
}