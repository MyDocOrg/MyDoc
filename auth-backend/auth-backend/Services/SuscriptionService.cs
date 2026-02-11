using auth_backend.DAL;
using auth_backend.DTO.Contants;
using auth_backend.Exceptions;
using auth_backend.Models;

namespace auth_backend.Services
{
    public class SuscriptionService(SuscriptionDAL dAL, ApplicationDAL applicationDAL)
    {
        private readonly SuscriptionDAL _dAL = dAL;
        private readonly ApplicationDAL _applicationDAL = applicationDAL;
        public async Task<ApiResponse<List<Suscription>>> GetByMyDoc()
        {
            var application = await _applicationDAL.GetApplicationByName("MyDoc");
            if (application == null)
                throw new BusinessException("Application not found", 404);

            var result = await _dAL.GetByApplicationId(application.Id);
            return ApiResponse<List<Suscription>>.Ok(result);
        }
        public async Task<ApiResponse<List<Suscription>>> GetByMyVet()
        {
            var application = await _applicationDAL.GetApplicationByName("MyVet");
            if (application == null)
                throw new BusinessException("Application not found", 404);

            var result = await _dAL.GetByApplicationId(application.Id);
            return ApiResponse<List<Suscription>>.Ok(result);
        }
        public async Task<ApiResponse<List<Suscription>>> GetList()
        {
            var result = await _dAL.GetList();
            return ApiResponse<List<Suscription>>.Ok(result);
        }
    }
}
