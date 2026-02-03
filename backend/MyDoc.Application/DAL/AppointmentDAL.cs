using Microsoft.EntityFrameworkCore;
using MyDoc.Application.BO.DTO.Appointment;
using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class AppointmentDAL : AbstractDAL<Appointment>
    {
        private readonly ApplicationDbContext _context;

        public AppointmentDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AppointmentTableDTO>> GetTable()
        {

            return await (from ap in _context.Appointment
                          join doc in _context.Doctor on ap.doctor_id equals doc.id
                          join clin in _context.Clinic on ap.clinic_id equals clin.id
                          join est in _context.AppointmentStatus on ap.status_id equals est.id
                          join pac in _context.Patient on ap.patient_id equals pac.id
                          select new AppointmentTableDTO
                          {
                              AppointmentDate = ap.appointment_date,
                              ClinicId = clin.id,
                              ClinicName = clin.name,
                              DoctorId = doc.id,
                              DoctorName = doc.full_name,    
                              Id = ap.id,
                              StatusId = est.id,
                              StatusName = est.name,
                              PatientId = pac.id,
                              PatientName = pac.full_name
                          }).ToListAsync();
        }

        public async Task<List<Appointment>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<Appointment?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<Appointment> Create(Appointment entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Appointment> Update(Appointment entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
