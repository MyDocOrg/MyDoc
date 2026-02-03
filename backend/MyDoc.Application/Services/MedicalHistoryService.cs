using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyDoc.Application.BO.DTO.MedicalHistory;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class MedicalHistoryService
    {
        private readonly MedicalHistoryDAL _dAL;
        private readonly MedicalHistoryMapper _mapper;

        public MedicalHistoryService(MedicalHistoryDAL dAL, MedicalHistoryMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<MedicalHistoryDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(m => _mapper.ToDTO(m)).ToList();
                return ApiResponse<List<MedicalHistoryDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<MedicalHistoryDTO>>.Fail("Error getting medical histories");
            }
        }

        public async Task<ApiResponse<MedicalHistoryDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<MedicalHistoryDTO?>.Ok(null);
                return ApiResponse<MedicalHistoryDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicalHistoryDTO?>.Fail("Error getting medical history");
            }
        }

        public async Task<ApiResponse<MedicalHistoryDTO>> Create(MedicalHistoryRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Create(entity);
                return ApiResponse<MedicalHistoryDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicalHistoryDTO>.Fail("Error creating medical history");
            }
        }

        public async Task<ApiResponse<MedicalHistoryDTO>> Update(MedicalHistoryRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Update(entity);
                return ApiResponse<MedicalHistoryDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicalHistoryDTO>.Fail("Error updating medical history");
            }
        }
    }
}
