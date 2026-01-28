using auth_backend.DAL;
using auth_backend.DTO.Auth;
using auth_backend.DTO.Contants;
using auth_backend.Helper;
using auth_backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace auth_backend.Services
{
    public class AuthService(AuthDAL dAL, JwtHelper jwtHelper, ApplicationDAL applicationDAL, RoleDAL roleDAL, MyDocDAL myDocDAL, MyVetDAL myVetDAL)
    {
        private readonly AuthDAL _dAL = dAL;
        private readonly JwtHelper _jwtHelper = jwtHelper;
        private readonly MyDocDAL _myDocDAL = myDocDAL;
        private readonly MyVetDAL _myVetDAL = myVetDAL;
        public async Task<ApiResponse<string>> Login(AuthLoginRequest request, string application)
        {
            try
            {
                var user = await _dAL.UserByEmail(request.Email);
                if (user == null)
                    throw new Exception("User not found");
                if (!PasswordHelper.VerifyPassword(request.Password, user.Password))
                    throw new Exception("Invalidad password");

                var result = await _dAL.UserPermissions(user.Id);
                var token = _jwtHelper.GenerateToken(result);

                return ApiResponse<string>.Ok(token);
            }
            catch
            {
                return ApiResponse<string>.Fail("Error while login");
            }
        }
        public async Task<ApiResponse<User>> RegisterVeterinarianMyVet(AuthRegisterVeterinarianRequest request)
        {
            try
            {
                var user = await _dAL.Add(new User
                {
                    ApplicationId = request.ApplicationId,
                    Email = request.Email,
                    Password = PasswordHelper.HashPassword(request.Password) ,
                    RoleId = request.RoleId,
                    SuscriptionId = request.SuscriptionId
                });

                _myVetDAL.AddVeterinarian(new Veterinarian
                {
                    is_active = true,
                    specialty = request.specialty,
                    created_at = DateTime.UtcNow,
                    email = request.Email,
                    full_name = request.full_name,
                    phone = request.phone,
                    professional_license = request.professional_license,
                    user_id = user.Id
                });


                return ApiResponse<User>.Ok(user);
            }
            catch
            {
                return ApiResponse<User>.Fail("Error while login");
            }
        }
        public async Task<ApiResponse<User>> RegisterOwnerMyVet(AuthRegisterOwnerRequest request)
        {
            try
            {
                var user = await _dAL.Add(new User
                {
                    ApplicationId = request.ApplicationId,
                    Email = request.Email,
                    Password = PasswordHelper.HashPassword(request.Password),
                    RoleId = request.RoleId,
                    SuscriptionId = request.SuscriptionId
                });

                _myVetDAL.AddOwner(new Owner
                {
                    is_active = true,
                    address = request.address,
                    birth_date = request.birth_date,
                    email = request.Email,
                    full_name = request.full_name,
                    gender = request.gender,
                    phone = request.phone,
                    created_at = DateTime.UtcNow,
                    user_id = user.Id
                });

                return ApiResponse<User>.Ok(user);
            }
            catch
            {
                return ApiResponse<User>.Fail("Error while login");
            }
        }
        public async Task<ApiResponse<User>> RegisterDoctorMyDoc(AuthRegisterDoctorRequest request)
        {
            try
            {
                var user = await _dAL.Add(new User
                {
                    ApplicationId = request.ApplicationId,
                    Email = request.Email,
                    Password = PasswordHelper.HashPassword(request.Password),
                    RoleId = request.RoleId,
                    SuscriptionId = request.SuscriptionId
                });

                await _myDocDAL.AddDoctor(new Doctor
                {
                    is_active = true,
                    specialty = request.specialty,
                    created_at = DateTime.UtcNow,
                    email = request.Email,
                    full_name = request.full_name,
                    phone = request.phone,
                    professional_license = request.professional_license,
                    user_id = user.Id
                });

                return ApiResponse<User>.Ok(user);
            }
            catch
            {
                return ApiResponse<User>.Fail("Error while login");
            }
        }
        public async Task<ApiResponse<User>> RegisterPatientMyDoc(AuthRegisterPatientRequest request)
        {
            try
            {
                var user = await _dAL.Add(new User
                {
                    ApplicationId = request.ApplicationId,
                    Email = request.Email,
                    Password = PasswordHelper.HashPassword(request.Password),
                    RoleId = request.RoleId,
                    SuscriptionId = request.SuscriptionId
                });

                await _myDocDAL.AddPatient(new Patient
                {
                    is_active = true,
                    address = request.address,
                    birth_date = request.birth_date,
                    email = request.Email,
                    full_name = request.full_name,
                    gender = request.gender,
                    phone = request.phone,
                    created_at = DateTime.UtcNow,
                    user_id = user.Id
                });

                return ApiResponse<User>.Ok(user);
            }
            catch
            {
                return ApiResponse<User>.Fail("Error while login");
            }
        }
    }
}
