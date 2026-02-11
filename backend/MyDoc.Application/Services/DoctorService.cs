using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.DTO.Doctor;
using MyDoc.Application.BO.Mappers;

namespace MyDoc.Application.Services
{
    public class DoctorService
    {
        private readonly DoctorDAL _dAL;
        private readonly DoctorMapper _mapper;

        public DoctorService(DoctorDAL dAL, DoctorMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<DoctorTableDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(d => _mapper.ToDoctorTableDTO(d)).ToList();
                return ApiResponse<List<DoctorTableDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<DoctorTableDTO>>.Fail("Error getting doctors");
            }
        }

        public async Task<ApiResponse<DoctorDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<DoctorDTO?>.Ok(null);
                return ApiResponse<DoctorDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<DoctorDTO?>.Fail("Error getting doctor");
            }
        }

        public async Task<ApiResponse<DoctorDTO>> Create(DoctorRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                entity.is_active = dto.IsActive ?? true;
                entity.created_at = System.DateTime.UtcNow;
                var result = await _dAL.Create(entity);
                return ApiResponse<DoctorDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<DoctorDTO>.Fail("Error creating doctor");
            }
        }

        public async Task<ApiResponse<DoctorDTO>> Update(DoctorRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                entity.updated_at = System.DateTime.UtcNow;
                var result = await _dAL.Update(entity);
                return ApiResponse<DoctorDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<DoctorDTO>.Fail("Error updating doctor");
            }
        }
    }
}
