using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Application.BO.DTO.ClinicDoctor;
using MyDoc.Application.BO.Mappers;

namespace MyDoc.Application.Services
{
    public class ClinicDoctorService
    {
        private readonly ClinicDoctorDAL _dAL;
        private readonly ClinicDoctorMapper _mapper;

        public ClinicDoctorService(ClinicDoctorDAL dAL, ClinicDoctorMapper mapper)
        {
            _dAL = dAL;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<ClinicDoctorTableDTO>>> GetAll()
        {
            try
            {
                var result = await _dAL.GetAll();
                var mapped = result.Select(c => _mapper.ToTableDTO(c)).ToList();
                return ApiResponse<List<ClinicDoctorTableDTO>>.Ok(mapped);
            }
            catch
            {
                return ApiResponse<List<ClinicDoctorTableDTO>>.Fail("Error getting clinic doctors");
            }
        }

        public async Task<ApiResponse<ClinicDoctorDTO?>> GetById(int id)
        {
            try
            {
                var result = await _dAL.GetById(id);
                if (result == null) return ApiResponse<ClinicDoctorDTO?>.Ok(null);
                return ApiResponse<ClinicDoctorDTO?>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<ClinicDoctorDTO?>.Fail("Error getting clinic doctor");
            }
        }

        public async Task<ApiResponse<ClinicDoctorDTO>> Create(ClinicDoctorRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Create(entity);
                return ApiResponse<ClinicDoctorDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<ClinicDoctorDTO>.Fail("Error creating clinic doctor");
            }
        }

        public async Task<ApiResponse<ClinicDoctorDTO>> Update(ClinicDoctorRequestDTO dto)
        {
            try
            {
                var entity = _mapper.ToEntity(dto);
                var result = await _dAL.Update(entity);
                return ApiResponse<ClinicDoctorDTO>.Ok(_mapper.ToDTO(result));
            }
            catch
            {
                return ApiResponse<ClinicDoctorDTO>.Fail("Error updating clinic doctor");
            }
        }
    }
}
