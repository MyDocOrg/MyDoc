using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyDoc.Application.BO.DTO.AppointmentStatus;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class AppointmentStatusService
    {
        private readonly AppointmentStatusDAL _dAL;
        private readonly AppointmentStatusMapper _mapper;

        public AppointmentStatusService(AppointmentStatusDAL dAL, AppointmentStatusMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<AppointmentStatusTableDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(s => _mapper.ToTableDTO(s)).ToList();
                return ApiResponse<List<AppointmentStatusTableDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<AppointmentStatusTableDTO>>.Fail("Error getting appointment statuses");
            }
        }

        public async Task<ApiResponse<AppointmentStatusDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<AppointmentStatusDTO?>.Ok(null);
                return ApiResponse<AppointmentStatusDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<AppointmentStatusDTO?>.Fail("Error getting appointment status");
            }
        }

        public async Task<ApiResponse<AppointmentStatusDTO>> Create(AppointmentStatusRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Create(entity);
                return ApiResponse<AppointmentStatusDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<AppointmentStatusDTO>.Fail("Error creating appointment status");
            }
        }

        public async Task<ApiResponse<AppointmentStatusDTO>> Update(AppointmentStatusRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Update(entity);
                return ApiResponse<AppointmentStatusDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<AppointmentStatusDTO>.Fail("Error updating appointment status");
            }
        }
    }
}
