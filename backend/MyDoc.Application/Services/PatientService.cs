using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.Services
{
    public class PatientService(PatientDAL dAL)
    {
        private readonly PatientDAL _dAL = dAL;
        public async Task<ApiResponse<List<Patient>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Patient>>.Ok(result);
        }
    }
}
