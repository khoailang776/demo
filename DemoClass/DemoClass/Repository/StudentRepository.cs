using DemoClass.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoClass.Repository
{
    public class StudentRepository : EntityBaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
