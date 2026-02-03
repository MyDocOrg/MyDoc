using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyDoc.Application.BO.DTO.MedicationSchedule;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class MedicationScheduleService
    {
        private readonly MedicationScheduleDAL _dAL;
        private readonly MedicationScheduleMapper _mapper;

        public MedicationScheduleService(MedicationScheduleDAL dAL, MedicationScheduleMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<MedicationScheduleDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(ms => _mapper.ToDTO(ms)).ToList();
                return ApiResponse<List<MedicationScheduleDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<MedicationScheduleDTO>>.Fail("Error getting medication schedules");
            }
        }

        public async Task<ApiResponse<MedicationScheduleDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<MedicationScheduleDTO?>.Ok(null);
                return ApiResponse<MedicationScheduleDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicationScheduleDTO?>.Fail("Error getting medication schedule");
            }
        }

        public async Task<ApiResponse<MedicationScheduleDTO>> Create(MedicationScheduleRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Create(entity);
                return ApiResponse<MedicationScheduleDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicationScheduleDTO>.Fail("Error creating medication schedule");
            }
        }

        public async Task<ApiResponse<MedicationScheduleDTO>> Update(MedicationScheduleRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Update(entity);
                return ApiResponse<MedicationScheduleDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<MedicationScheduleDTO>.Fail("Error updating medication schedule");
            }
        }
    }
}
