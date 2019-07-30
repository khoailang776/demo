using System;
using System.Collections.Generic;

namespace DemoClass.Models
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StudentName { get; set; }
        public int Age { get; set; }
        public Guid ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
