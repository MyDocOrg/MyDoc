using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyDoc.Application.BO.DTO.Notification;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.Contants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class NotificationService
    {
        private readonly NotificationDAL _dAL;
        private readonly NotificationMapper _mapper;

        public NotificationService(NotificationDAL dAL, NotificationMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<NotificationDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(n => _mapper.ToDTO(n)).ToList();
                return ApiResponse<List<NotificationDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<NotificationDTO>>.Fail("Error getting notifications");
            }
        }

        public async Task<ApiResponse<NotificationDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<NotificationDTO?>.Ok(null);
                return ApiResponse<NotificationDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<NotificationDTO?>.Fail("Error getting notification");
            }
        }

        public async Task<ApiResponse<NotificationDTO>> Create(NotificationRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Create(entity);
                return ApiResponse<NotificationDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<NotificationDTO>.Fail("Error creating notification");
            }
        }

        public async Task<ApiResponse<NotificationDTO>> Update(NotificationRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Update(entity);
                return ApiResponse<NotificationDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<NotificationDTO>.Fail("Error updating notification");
            }
        }
    }
}
