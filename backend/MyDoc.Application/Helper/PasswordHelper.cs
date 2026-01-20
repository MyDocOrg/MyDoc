using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Application.Helper
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
