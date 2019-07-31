using System;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DemoClass.Config;
using DemoClass.Contracts;
using DemoClass.Services.Student;
using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace DemoClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenderPDFController : ControllerBase
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly IStudentService _studentService;
        public RenderPDFController(IStudentService studentService, IGeneratePdf generatePdf)
        {
            _studentService = studentService;
            _generatePdf = generatePdf;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilePDFAsync(Guid id, [FromQuery] PaginationContract pCon)
        {
            var listStudent = await _studentService.ListStudentInClassAsync(id, pCon);
            var pdf = await _generatePdf.GetByteArray("HTML/Demo.cshtml", listStudent.Sources);
            var pdfStream = new MemoryStream();
            pdfStream.Write(pdf, 0, pdf.Length);
            pdfStream.Position = 0;
            return new FileStreamResult(pdfStream, "application/pdf");
        }
    }
}