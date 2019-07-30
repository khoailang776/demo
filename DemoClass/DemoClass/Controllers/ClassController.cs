using System.Threading.Tasks;
using DemoClass.Contracts.Class;
using DemoClass.Services.Class;
using Microsoft.AspNetCore.Mvc;

namespace DemoClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]ClassRequest clsR)
        {
            return Ok(await _classService.AddClassAsync(clsR));
        }
    }
}