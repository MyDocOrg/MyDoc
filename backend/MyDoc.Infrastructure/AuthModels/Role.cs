using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Infrastructure.AuthModels
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ApplicationId { get; set; }
    }
}
