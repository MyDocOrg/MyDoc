using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class NotificationService
    {
        private readonly NotificationDAL _dAL;

        public NotificationService(NotificationDAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<Notification>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Notification>>.Ok(result);
        }

        public async Task<ApiResponse<Notification?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Notification?>.Ok(result);
        }

        public async Task<ApiResponse<Notification>> Create(Notification entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<Notification>.Ok(result);
        }

        public async Task<ApiResponse<Notification>> Update(Notification entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Notification>.Ok(result);
        }
    }
}
