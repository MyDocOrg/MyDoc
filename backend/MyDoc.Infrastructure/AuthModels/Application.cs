using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Infrastructure.AuthModels
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
