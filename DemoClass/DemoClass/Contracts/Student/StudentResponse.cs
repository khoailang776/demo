using DemoClass.Contracts.Class;

namespace DemoClass.Contracts.Student
{
    public class StudentResponse
    {
        public string StudentName { get; set; }
        public int Age { get; set; }
        public ClassResponse Class { get; set; }
    }
}
