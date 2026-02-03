using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.BO.DTO.Appointment
{
    public record AppointmentTableDTO
    {
        public int Id { get; set; }

        public string DoctorName { get; set; } = null!;

        public int DoctorId { get; set; }

        public int ClinicId { get; set; }

        public string ClinicName { get; set; } = null!;

        public int StatusId { get; set; }

        public string StatusName { get; set; } = null!;

        public int PatientId { get; set; }

        public string PatientName { get; set; } = null!;

        public DateTime? AppointmentDate { get; set; }
    }
}
