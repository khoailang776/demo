using System;
using System.Threading.Tasks;
using DemoClass.Contracts;
using DemoClass.Contracts.Student;
using DemoClass.Services.Student;
using Microsoft.AspNetCore.Mvc;

namespace DemoClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // List student in class
        [HttpGet("Class/{id}")]
        public async Task<IActionResult> ListStudentInClass(Guid id,[FromQuery] PaginationContract pCon)
        {
            return Ok(await _studentService.ListStudentInClassAsync(id, pCon));
        }
        // Add new student
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]StudentRequest stdR)
        {
            return Ok(await _studentService.AddStudentAsync(stdR));
        }
        // Update student
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id,[FromBody]StudentRequest stdR)
        {
            return Ok(await _studentService.UpdateStudentAsync(id, stdR));
        }
        // Remove student
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            return Ok(await _studentService.RemoveStudentAsync(id));
        }
    }
}