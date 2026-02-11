using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.DTO.MedicalHistory;
using MyDoc.Application.BO.Mappers;

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
            var result = await _dAL.GetAll();
            var mapped = result.Select(m => _mapper.ToDTO(m)).ToList();
            return ApiResponse<List<MedicalHistoryDTO>>.Ok(mapped);
        }

        public async Task<ApiResponse<MedicalHistoryDTO?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            if (result == null) return ApiResponse<MedicalHistoryDTO?>.Ok(null);
            return ApiResponse<MedicalHistoryDTO?>.Ok(_mapper.ToDTO(result));
        }

        public async Task<ApiResponse<MedicalHistoryDTO>> Create(MedicalHistoryRequestDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            var result = await _dAL.Create(entity);
            return ApiResponse<MedicalHistoryDTO>.Ok(_mapper.ToDTO(result));
        }

        public async Task<ApiResponse<MedicalHistoryDTO>> Update(MedicalHistoryRequestDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            var result = await _dAL.Update(entity);
            return ApiResponse<MedicalHistoryDTO>.Ok(_mapper.ToDTO(result));
        }
    }
}
