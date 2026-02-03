using System.Collections.Generic;
using MyDoc.Application.BO.DTO.PrescriptionMedicine;
using MyDoc.Application.BO.DTO.MedicationSchedule;

namespace MyDoc.Application.BO.DTO.Prescription
{
    public record PrescriptionDTO
    {
        public int Id { get; init; }
        public string? GeneralInstructions { get; init; }
        public int MedicalHistoryId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public List<PrescriptionMedicineDTO>? Medicines { get; init; }
        public List<MedicationScheduleDTO>? MedicationSchedules { get; init; }
    }
}