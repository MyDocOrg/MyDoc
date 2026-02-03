using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyDoc.Application.BO.DTO.Patient;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class PatientService
    {
        private readonly PatientDAL _dAL;
        private readonly PatientMapper _mapper;

        public PatientService(PatientDAL dAL, PatientMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<PatientTableDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(p => _mapper.ToTableDTO(p)).ToList();
                return ApiResponse<List<PatientTableDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<PatientTableDTO>>.Fail("Error getting patients");
            }
        }

        public async Task<ApiResponse<PatientDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<PatientDTO?>.Ok(null);
                return ApiResponse<PatientDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<PatientDTO?>.Fail("Error getting patient");
            }
        }

        public async Task<ApiResponse<PatientDTO>> Create(PatientRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                entity.is_active = dto.IsActive ?? true;
                entity.created_at = System.DateTime.UtcNow;
                var result = await _dAL.Create(entity);
                return ApiResponse<PatientDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<PatientDTO>.Fail("Error creating patient");
            }
        }

        public async Task<ApiResponse<PatientDTO>> Update(PatientRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                entity.updated_at = System.DateTime.UtcNow;
                var result = await _dAL.Update(entity);
                return ApiResponse<PatientDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<PatientDTO>.Fail("Error updating patient");
            }
        }

        public async Task<ApiResponse<bool>> Delete(int id)
        {
            var result = await _dAL.Delete(id);
            return ApiResponse<bool>.Ok(result);
        }
    }
}
