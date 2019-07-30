using System.ComponentModel.DataAnnotations;

namespace DemoClass.Contracts.Class
{
    public class ClassRequest
    {
        [Required]
        [MaxLength(10)]
        public string ClassName { get; set; }
    }
}
