using System;
using System.Collections.Generic;

namespace DemoClass.Models
{
    public class Class
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ClassName { get; set; }
    }
}
