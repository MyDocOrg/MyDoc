using auth_backend.DAL;
using auth_backend.DTO.Contants;
using auth_backend.Exceptions;
using auth_backend.Models;

namespace auth_backend.Services
{
    public class RoleService(RoleDAL dAL, ApplicationDAL applicationDAL)
    {
        private readonly RoleDAL _dAL = dAL;
        private readonly ApplicationDAL _applicationDAL = applicationDAL;
        public async Task<ApiResponse<List<Role>>> GetByMyDoc()
        {
            var application = await _applicationDAL.GetApplicationByName("MyDoc");
            if (application == null)
                throw new BusinessException("Application not found", 404);

            var result = await _dAL.GetByApplicationId(application.Id);
            return ApiResponse<List<Role>>.Ok(result);
        }
        public async Task<ApiResponse<List<Role>>> GetByMyVet()
        {
            var application = await _applicationDAL.GetApplicationByName("MyVet");
            if (application == null)
                throw new BusinessException("Application not found", 404);

            var result = await _dAL.GetByApplicationId(application.Id);
            return ApiResponse<List<Role>>.Ok(result);
        }
        public async Task<ApiResponse<List<Role>>> GetList()
        {
            var result = await _dAL.GetList();
            return ApiResponse<List<Role>>.Ok(result);
        }
    }
}
