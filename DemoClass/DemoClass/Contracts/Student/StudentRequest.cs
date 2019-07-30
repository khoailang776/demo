using System;
using System.ComponentModel.DataAnnotations;

namespace DemoClass.Contracts.Student
{
    public class StudentRequest
    {
        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        public Guid ClassId { get; set; }
    }
}
