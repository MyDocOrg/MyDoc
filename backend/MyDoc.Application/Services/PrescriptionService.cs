using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyDoc.Application.BO.DTO.Prescription;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class PrescriptionService
    {
        private readonly PrescriptionDAL _dAL;
        private readonly PrescriptionMapper _mapper;

        public PrescriptionService(PrescriptionDAL dAL, PrescriptionMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<PrescriptionDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(p => _mapper.ToDTO(p)).ToList();
                return ApiResponse<List<PrescriptionDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<PrescriptionDTO>>.Fail("Error getting prescriptions");
            }
        }

        public async Task<ApiResponse<PrescriptionDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<PrescriptionDTO?>.Ok(null);
                return ApiResponse<PrescriptionDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<PrescriptionDTO?>.Fail("Error getting prescription");
            }
        }

        public async Task<ApiResponse<PrescriptionDTO>> Create(PrescriptionRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Create(entity);
                return ApiResponse<PrescriptionDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<PrescriptionDTO>.Fail("Error creating prescription");
            }
        }

        public async Task<ApiResponse<PrescriptionDTO>> Update(PrescriptionRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Update(entity);
                return ApiResponse<PrescriptionDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<PrescriptionDTO>.Fail("Error updating prescription");
            }
        }
    }
}
