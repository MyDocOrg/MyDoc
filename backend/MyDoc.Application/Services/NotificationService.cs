using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.DTO.Notification;
using MyDoc.Application.BO.Mappers;

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
            var result = await _dAL.GetAll();
            var mapped = result.Select(n => _mapper.ToDTO(n)).ToList();
            return ApiResponse<List<NotificationDTO>>.Ok(mapped);
        }

        public async Task<ApiResponse<NotificationDTO?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            if (result == null) return ApiResponse<NotificationDTO?>.Ok(null);
            return ApiResponse<NotificationDTO?>.Ok(_mapper.ToDTO(result));
        }

        public async Task<ApiResponse<NotificationDTO>> Create(NotificationRequestDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            var result = await _dAL.Create(entity);
            return ApiResponse<NotificationDTO>.Ok(_mapper.ToDTO(result));
        }

        public async Task<ApiResponse<NotificationDTO>> Update(NotificationRequestDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            var result = await _dAL.Update(entity);
            return ApiResponse<NotificationDTO>.Ok(_mapper.ToDTO(result));
        }
    }
}
