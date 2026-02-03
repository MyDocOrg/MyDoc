using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.BO.DTO.Clinic
{
    public record ClinicTableDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public string? OwnerName { get; set; }
    }
}
