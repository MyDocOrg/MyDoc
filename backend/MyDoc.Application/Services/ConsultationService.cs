using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyDoc.Application.BO.DTO.Consultation;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class ConsultationService
    {
        private readonly ConsultationDAL _dAL;
        private readonly ConsultationMapper _mapper;

        public ConsultationService(ConsultationDAL dAL, ConsultationMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<ConsultationDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(c => _mapper.ToDTO(c)).ToList();
                return ApiResponse<List<ConsultationDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<ConsultationDTO>>.Fail("Error getting consultations");
            }
        }

        public async Task<ApiResponse<ConsultationDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<ConsultationDTO?>.Ok(null);
                return ApiResponse<ConsultationDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<ConsultationDTO?>.Fail("Error getting consultation");
            }
        }

        public async Task<ApiResponse<ConsultationDTO>> Create(ConsultationRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Create(entity);
                return ApiResponse<ConsultationDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<ConsultationDTO>.Fail("Error creating consultation");
            }
        }

        public async Task<ApiResponse<ConsultationDTO>> Update(ConsultationRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Update(entity);
                return ApiResponse<ConsultationDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<ConsultationDTO>.Fail("Error updating consultation");
            }
        }
    }
}
