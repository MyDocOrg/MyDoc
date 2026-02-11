using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.DTO.PrescriptionMedicine;
using MyDoc.Application.BO.Mappers;

namespace MyDoc.Application.Services
{
    public class PrescriptionMedicineService
    {
        private readonly PrescriptionMedicineDAL _dAL;
        private readonly PrescriptionMedicineMapper _mapper;

        public PrescriptionMedicineService(PrescriptionMedicineDAL dAL, PrescriptionMedicineMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<PrescriptionMedicineDTO>>> GetAll()
        {
            var result = await _dAL.GetAll();
            var mapped = result.Select(pm => _mapper.ToDTO(pm)).ToList();
            return ApiResponse<List<PrescriptionMedicineDTO>>.Ok(mapped);
        }

        public async Task<ApiResponse<PrescriptionMedicineDTO?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            if (result == null) return ApiResponse<PrescriptionMedicineDTO?>.Ok(null);
            return ApiResponse<PrescriptionMedicineDTO?>.Ok(_mapper.ToDTO(result));
        }

        public async Task<ApiResponse<PrescriptionMedicineDTO>> Create(PrescriptionMedicineRequestDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            var result = await _dAL.Create(entity);
            return ApiResponse<PrescriptionMedicineDTO>.Ok(_mapper.ToDTO(result));
        }

        public async Task<ApiResponse<PrescriptionMedicineDTO>> Update(PrescriptionMedicineRequestDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            var result = await _dAL.Update(entity);
            return ApiResponse<PrescriptionMedicineDTO>.Ok(_mapper.ToDTO(result));
        }
    }
}
