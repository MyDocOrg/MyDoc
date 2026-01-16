using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class PrescriptionMedicineService
    {
        private readonly PrescriptionMedicineDAL _dAL;

        public PrescriptionMedicineService(PrescriptionMedicineDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<PrescriptionMedicine>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<PrescriptionMedicine>>.Ok(result);
        }

        public async Task<ApiResponse<PrescriptionMedicine?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<PrescriptionMedicine?>.Ok(result);
        }

        public async Task<ApiResponse<PrescriptionMedicine>> Create(PrescriptionMedicine entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<PrescriptionMedicine>.Ok(result);
        }

        public async Task<ApiResponse<PrescriptionMedicine>> Update(PrescriptionMedicine entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<PrescriptionMedicine>.Ok(result);
        }
    }
}
