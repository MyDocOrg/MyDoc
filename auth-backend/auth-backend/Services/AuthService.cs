using auth_backend.DAL;
using auth_backend.DTO.Auth;
using auth_backend.DTO.Contants;
using auth_backend.Exceptions;
using auth_backend.Helper;
using auth_backend.Models;
using MySqlX.XDevAPI.Common;
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
        private readonly RoleDAL _roleDAL = roleDAL;
        private readonly ApplicationDAL _applicationDAL = applicationDAL;
        public async Task<ApiResponse<string>> Login(AuthLoginRequest request, string application)
        {
            var user = await _dAL.UserByEmail(request.Email);

            if (user == null)
                throw new BusinessException("User not found", 404);

            if (!PasswordHelper.VerifyPassword(request.Password, user.Password))
                throw new BusinessException("Invalid password", 401);

            var result = await _dAL.UserPermissions(user.Id);

            switch (result.RoleName)
            {
                case "Paciente":
                    result.PatientId =
                        (await _myDocDAL.GetByUserIdPatient(user.Id)).id;
                    break;

                case "Doctor":
                    result.DoctorId =
                        (await _myDocDAL.GetByUserIdDoctor(user.Id)).id;
                    break;

                case "Admin":
                    result.DoctorId =
                        (await _myDocDAL.GetByUserIdDoctor(user.Id)).id;

                    result.PatientId =
                        (await _myDocDAL.GetByUserIdPatient(user.Id)).id;
                    break;
            }

            var token = _jwtHelper.GenerateToken(result);

            return ApiResponse<string>.Ok(token);
        }
        public async Task<ApiResponse<User>> RegisterVeterinarianMyVet(AuthRegisterVeterinarianRequest request)
        {
            if(await _dAL.AnyUserByEmailApplication(request.Email, request.ApplicationId))
                throw new BusinessException("Email already exists used it", 400);

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
        public async Task<ApiResponse<User>> RegisterOwnerMyVet(AuthRegisterOwnerRequest request)
        {
            if (await _dAL.AnyUserByEmailApplication(request.Email, request.ApplicationId))
                throw new BusinessException("Email already exists used it", 400);

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
        public async Task<ApiResponse<User>> RegisterDoctorMyDoc(AuthRegisterDoctorRequest request)
        {
            if (await _dAL.AnyUserByEmailApplication(request.Email, request.ApplicationId))
                throw new BusinessException("Email already exists used it", 400);

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
        public async Task<ApiResponse<User>> RegisterPatientMyDoc(AuthRegisterPatientRequest request)
        {
            if (await _dAL.AnyUserByEmailApplication(request.Email, request.ApplicationId))
                throw new BusinessException("Email already exists used it", 400);

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
        public async Task<ApiResponse<User>> RegisterUserMyDoc(AuthUserRequest request)
        {
            if (await _dAL.AnyUserByEmailApplication(request.Email, request.ApplicationId))
                throw new BusinessException("Email already exists used it", 400);

            var role = await _roleDAL.GetById(request.RoleId);
            if (role == null)
                throw new Exception("Role not found");

            var user = await _dAL.Add(new User
            {
                ApplicationId = request.ApplicationId,
                Email = request.Email,
                Password = PasswordHelper.HashPassword(request.Password),
                RoleId = request.RoleId,
                SuscriptionId = request.SuscriptionId
            });

            switch (role.Name)
            {
                case "Paciente":
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
                    break;

                case "Doctor":
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
                    break;

                case "Admin":
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
                    break;

                default:
                    break; // Admin, Staff, etc.
            }

            return ApiResponse<User>.Ok(user);
        }
    }
}
