using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Clinic;
using MyDoc.Application.DAL;
using MyDoc.Application.Helper;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class ClinicService
    {
        private readonly ClinicDAL _dAL;
        private readonly CurrentUserHelper _currentUserHelper;

        public ClinicService(ClinicDAL dAL, CurrentUserHelper currentUserHelper)
        {
            _dAL = dAL;
            _currentUserHelper = currentUserHelper;
        }
        public async Task<ApiResponse<List<Clinic>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<Clinic>>.Ok(result);
        }

        public async Task<ApiResponse<Clinic?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<Clinic?>.Ok(result);
        }

        public async Task<ApiResponse<Clinic>> Create(ClinicRequestDTO entity)
        {
            try
            {
                var result = await _dAL.Create(new Clinic
                {
                    name = entity.name,
                    address = entity.address,
                    phone = entity.phone,
                    email = entity.email,
                    is_active = true,
                    created_at = System.DateTime.UtcNow
                });
                return ApiResponse<Clinic>.Ok(result);
            }
            catch
            {
                return ApiResponse<Clinic>.Fail("Error creating Clinic");
            }
        }

        public async Task<ApiResponse<Clinic>> Update(Clinic entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<Clinic>.Ok(result);
        }
    }
}
