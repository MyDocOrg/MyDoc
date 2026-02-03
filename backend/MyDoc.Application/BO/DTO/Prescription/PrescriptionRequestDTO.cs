using System.Collections.Generic;
using MyDoc.Application.BO.DTO.PrescriptionMedicine;
using MyDoc.Application.BO.DTO.MedicationSchedule;

namespace MyDoc.Application.BO.DTO.Prescription
{
    public record PrescriptionRequestDTO
    {
        public int? Id { get; init; }
        public string? GeneralInstructions { get; init; }
        public int MedicalHistoryId { get; init; }
        public List<PrescriptionMedicineRequestDTO>? Medicines { get; init; }
        public List<MedicationScheduleRequestDTO>? MedicationSchedules { get; init; }
    }
}