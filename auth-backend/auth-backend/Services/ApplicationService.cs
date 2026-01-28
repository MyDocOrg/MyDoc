using auth_backend.DAL;
using auth_backend.DTO.Auth;
using auth_backend.DTO.Contants;
using auth_backend.Helper;
using auth_backend.Models;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace auth_backend.Services
{
    public class ApplicationService(ApplicationDAL dAL)
    {
        private readonly ApplicationDAL _dAL = dAL;
        public async Task<ApiResponse<Application>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                return ApiResponse<Application>.Ok(result);
            }
            catch
            {
                return ApiResponse<Application>.Fail("Error getting application");
            }
        }
        public async Task<ApiResponse<List<Application>>> GetList()
        {
            try
            {
                var result = await _dAL.GetList();
                return ApiResponse<List<Application>>.Ok(result);
            }
            catch
            {
                return ApiResponse<List<Application>>.Fail("Error getting application");
            }
        }
    }
}
