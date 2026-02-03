using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Clinic;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.Helper;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class ClinicService(ClinicDAL dAL, CurrentUserHelper currentUserHelper, ClinicMapper mapper)
    {
        private readonly ClinicDAL _dAL = dAL;
        private readonly CurrentUserHelper _currentUserHelper = currentUserHelper;
        private readonly ClinicMapper _mapper = mapper;
        public async Task<ApiResponse<List<ClinicTableDTO>>> GetTable()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapperResult = result.Select(p => _mapper.ToClinicTableDTO(p)).ToList();
                return ApiResponse<List<ClinicTableDTO>>.Ok(mapperResult);
            }
            catch
            {
                return ApiResponse<List<ClinicTableDTO>>.Fail("Error getting Clinics");
            }
        }
        public async Task<ApiResponse<List<Clinic>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                return ApiResponse<List<Clinic>>.Ok(result);
            }
            catch
            {
                return ApiResponse<List<Clinic>>.Fail("Error getting Clinic");
            }
        }

        public async Task<ApiResponse<ClinicDTO?>> GetById(int id)
        {
            try
            {
                var result = _mapper.ToDTO(await _dAL.GetById(id));
                return ApiResponse<ClinicDTO?>.Ok(result);
            }
            catch
            {
                return ApiResponse<ClinicDTO?>.Fail("Error getting Clinic");
            }
        }

        public async Task<ApiResponse<Clinic>> Create(ClinicRequestDTO entity)
        {
            try
            {
                var result = await _dAL.Create(new Clinic
                {
                    name = entity.Name,
                    address = entity.Address,
                    phone = entity.Phone,
                    email = entity.Email,
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

        public async Task<ApiResponse<Clinic>> Update(ClinicRequestDTO entity)
        {
            try
            {
                var result = await _dAL.Update(new Clinic
                {
                    id = entity.Id,
                    name = entity.Name,
                    address = entity.Address,
                    phone = entity.Phone,
                    email = entity.Email,
                    is_active = entity.IsActive,
                    updated_at = System.DateTime.UtcNow
                });
                return ApiResponse<Clinic>.Ok(result);
            }
            catch
            {
                return ApiResponse<Clinic>.Fail("Error modifying Clinic");
            }
        }
    }
}
