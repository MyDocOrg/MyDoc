using MyDoc.Application.BO.DTO.Prescription;
using MyDoc.Application.BO.DTO.PrescriptionMedicine;
using MyDoc.Application.BO.DTO.MedicationSchedule;
using MyDoc.Application.BO.Mappers;
using MyDoc.Infrastructure.Models;
using System.Linq;

namespace MyDoc.Application.BO.Mappers
{
    public class PrescriptionMapper
    {
        private readonly PrescriptionMedicineMapper _pmMapper = new PrescriptionMedicineMapper();
        private readonly MedicationScheduleMapper _msMapper = new MedicationScheduleMapper();

        public PrescriptionDTO ToDTO(Prescription p)
        {
            return new PrescriptionDTO
            {
                Id = p.id,
                GeneralInstructions = p.general_instructions,
                MedicalHistoryId = p.medical_history_id,
                CreatedAt = p.created_at,
                Medicines = p.PrescriptionMedicines?.Select(pm => _pmMapper.ToDTO(pm)).ToList(),
                MedicationSchedules = p.MedicationSchedules?.Select(ms => _msMapper.ToDTO(ms)).ToList()
            };
        }

        public Prescription ToEntity(PrescriptionRequestDTO dto)
        {
            var entity = new Prescription
            {
                id = dto.Id ?? 0,
                general_instructions = dto.GeneralInstructions,
                medical_history_id = dto.MedicalHistoryId,
                created_at = System.DateTime.UtcNow
            };

            // Children will be handled by DAL/services as needed (create separately)
            return entity;
        }
    }
}