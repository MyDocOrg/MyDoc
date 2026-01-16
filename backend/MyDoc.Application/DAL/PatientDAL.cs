using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.DAL
{
    public class PatientDAL : AbstracDAL<Patient>
    {
        private readonly ApplicationDbContext _context;
        public PatientDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Patient>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }
    }
}
