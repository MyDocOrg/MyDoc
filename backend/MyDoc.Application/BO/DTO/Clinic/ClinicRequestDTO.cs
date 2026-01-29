using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyDoc.Application.BO.DTO.Clinic
{
    public class ClinicRequestDTO
    {
        [Key]
        public int id { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? name { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? address { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        public string? phone { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? email { get; set; }
    }
}
