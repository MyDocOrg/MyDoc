using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.BO.DTO.User
{
    public record UserAuthDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; } = null!;

        public int SuscriptionId { get; set; }
        public string SuscriptionName { get; set; } = null!;
    }
}
