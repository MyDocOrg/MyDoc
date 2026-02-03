using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyDoc.Application.BO.DTO.Medicine;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class MedicineService
    {
        private readonly MedicineDAL _dAL;
        private readonly MedicineMapper _mapper;

        public MedicineService(MedicineDAL dAL, MedicineMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<MedicineTableDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(m => _mapper.ToTableDTO(m)).ToList();
                return ApiResponse<List<MedicineTableDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<MedicineTableDTO>>.Fail("Error getting medicines");
            }
        }

        public async Task<ApiResponse<MedicineDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<MedicineDTO?>.Ok(null);
                return ApiResponse<MedicineDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicineDTO?>.Fail("Error getting medicine");
            }
        }

        public async Task<ApiResponse<MedicineDTO>> Create(MedicineRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                entity.is_active = dto.IsActive ?? true;
                var result = await _dAL.Create(entity);
                return ApiResponse<MedicineDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicineDTO>.Fail("Error creating medicine");
            }
        }

        public async Task<ApiResponse<MedicineDTO>> Update(MedicineRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Update(entity);
                return ApiResponse<MedicineDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicineDTO>.Fail("Error updating medicine");
            }
        }
    }
}
