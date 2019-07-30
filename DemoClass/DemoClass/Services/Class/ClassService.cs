using DemoClass.Config;
using DemoClass.Contracts.Class;
using DemoClass.Repository;
using System;
using System.Threading.Tasks;

namespace DemoClass.Services.Class
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<ClassResponse> AddClassAsync(ClassRequest clsR)
        {
            var cls = await _classRepository.GetSingleAsync(c => c.ClassName == clsR.ClassName);
            if (cls == null)
            {
                var clas = new Models.Class
                {
                    ClassName = clsR.ClassName
                };
                if (await _classRepository.InsertAsync(clas))
                {
                    return clas.Map<ClassResponse>();
                }
            }
            throw new Exception();
        }
    }
}
