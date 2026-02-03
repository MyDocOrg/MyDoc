using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.BO.DTO.Appointment
{
    public record AppointmentRequestDTO
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int ClinicId { get; set; }

        public int StatusId { get; set; }

        public DateTime? AppointmentDate { get; set; }
    }
}
