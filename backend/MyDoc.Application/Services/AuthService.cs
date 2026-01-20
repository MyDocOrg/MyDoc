using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.DTO.Auth;
using MyDoc.Application.DAL;
using MyDoc.Application.Helper;
using MyDoc.Infrastructure.AuthModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.Services
{
    public class AuthService(AuthDAL dAL, JwtHelper jwtHelper)
    {
        private readonly AuthDAL _dAL = dAL;
        private readonly JwtHelper _jwtHelper = jwtHelper;
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
        public async Task<ApiResponse<User>> Register(AuthRegisterRequest request, string application)
        {
            try
            {
                var user = await _dAL.Add(new User
                {
                    Email = request.Email,
                    Password = PasswordHelper.HashPassword(request.Password) 
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
