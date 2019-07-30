using DemoClass.Contracts.Class;
using System.Threading.Tasks;

namespace DemoClass.Services.Class
{
    public interface IClassService
    {
        Task<ClassResponse> AddClassAsync(ClassRequest clsR);
    }
}
