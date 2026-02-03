using MyDoc.Application.BO.DTO.Clinic;
using MyDoc.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.BO.Mappers
{
    public class ClinicMapper
    {
        public ClinicDTO ToDTO(Infrastructure.Models.Clinic clinic)
        {
            return new ClinicDTO
            {
                Id = clinic.id,
                Name = clinic.name,
                Address = clinic.address,
                Phone = clinic.phone,
                Email = clinic.email,
                IsActive = clinic.is_active
            };
        }
        public ClinicTableDTO ToClinicTableDTO(Clinic clinic)
        {
            return new ClinicTableDTO
            {
                Id = clinic.id,
                Name = clinic.name,
                Address = clinic.address,
                Phone = clinic.phone,
                Email = clinic.email,
                IsActive = clinic.is_active
            };
        }
    }
}
