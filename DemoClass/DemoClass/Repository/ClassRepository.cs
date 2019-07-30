using DemoClass.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoClass.Repository
{
    public class ClassRepository : EntityBaseRepository<Class>, IClassRepository
    {
        public ClassRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
