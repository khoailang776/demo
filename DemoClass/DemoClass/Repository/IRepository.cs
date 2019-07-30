using DemoClass.Models;

namespace DemoClass.Repository
{
    public interface IClassRepository : IEntityBaseRepository<Class>
    {
    }
    public interface IStudentRepository : IEntityBaseRepository<Student>
    {
    }
}
