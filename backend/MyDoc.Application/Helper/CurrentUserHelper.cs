using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace MyDoc.Application.Helper
{
    public class CurrentUserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User =>
            _httpContextAccessor.HttpContext?.User;

        public bool IsAuthenticated =>
            User?.Identity?.IsAuthenticated ?? false;

        public int UserId =>
            int.TryParse(User?.FindFirst("id")?.Value, out var id)
                ? id
                : 0;

        public string Email =>
            User?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;

        public string Role =>
            User?.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;
    }
}
