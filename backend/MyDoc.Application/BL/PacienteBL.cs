using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.BL
{
    public class PacienteBL(PacienteDAL dAL)
    {
        private readonly PacienteDAL _dAL = dAL;
        public async Task<ApiResponse<List<Paciente>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                return ApiResponse<List<Paciente>>.Ok(result);
            }
            catch
            {
                return ApiResponse<List<Paciente>>.Fail("Something went wrong getting paciente", 500);
            }
        }
    }
}
