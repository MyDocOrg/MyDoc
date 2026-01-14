using MyDoc.Application.DAL.Abstract;
using MyDoc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.DAL
{
    public class PacienteDAL : AbstracDAL<Paciente>
    {
        private readonly ApplicationDbContext _context;
        public PacienteDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Paciente>> GetAll()
        {
            try
            {
                var result = await base.GetAllAsync();
                return result.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al obtener los pacientes", ex);
            }
        }
    }
}
