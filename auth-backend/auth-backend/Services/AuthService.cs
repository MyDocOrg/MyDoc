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
    public class AuthService(AuthDAL dAL, JwtHelper jwtHelper, ApplicationDAL applicationDAL, RoleDAL roleDAL)
    {
        private readonly AuthDAL _dAL = dAL;
        private readonly JwtHelper _jwtHelper = jwtHelper;
        private readonly ApplicationDAL _applicationDAL = applicationDAL;
        private readonly RoleDAL _roleDAL = roleDAL;
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
        public async Task<ApiResponse<User>> RegisterMyVet(AuthRegisterRequest request)
        {
            try
            {
                var app = await _applicationDAL.GetApplicationByName("MyVet");
                if (app == null)
                    throw new Exception("Application not found"); 

                var role = await _roleDAL.GetRoleByNameApplicationId(request.RoleName, app.Id);
                if (role == null)
                    throw new Exception("Role not found");

                var user = await _dAL.Add(new User
                {
                    ApplicationId = app.Id,
                    Email = request.Email,
                    Password = PasswordHelper.HashPassword(request.Password) ,
                    RoleId = role.Id,
                    SuscriptionId = request.SuscriptionId
                });

                return ApiResponse<User>.Ok(user);
            }
            catch
            {
                return ApiResponse<User>.Fail("Error while login");
            }
        }
        public async Task<ApiResponse<User>> RegisterMyDoc(AuthRegisterRequest request)
        {
            try
            {
                var app = await _applicationDAL.GetApplicationByName("MyDoc");
                if (app == null)
                    throw new Exception("Application not found");

                var role = await _roleDAL.GetRoleByNameApplicationId(request.RoleName, app.Id);
                if (role == null)
                    throw new Exception("Role not found");

                var user = await _dAL.Add(new User
                {
                    ApplicationId = app.Id,
                    Email = request.Email,
                    Password = PasswordHelper.HashPassword(request.Password),
                    RoleId = role.Id,
                    SuscriptionId = request.SuscriptionId
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
