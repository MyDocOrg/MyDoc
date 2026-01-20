using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.BO.DTO.Auth
{
    public record AuthLoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
