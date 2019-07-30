using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DemoClass.Config;
using DemoClass.Contracts;
using DemoClass.Contracts.Class;
using DemoClass.Contracts.Student;
using DemoClass.Repository;
using Microsoft.EntityFrameworkCore;

namespace DemoClass.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        public StudentService(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
        }
        public async Task<StudentResponse> AddStudentAsync(StudentRequest stdR)
        {
            var std = await _studentRepository.GetSingleAsync(c => c.StudentName == stdR.StudentName);
            if (std == null)
            {
                var student = new Models.Student
                {
                    ClassId = stdR.ClassId,
                    StudentName = stdR.StudentName,
                    Age = stdR.Age
                };
                if (await _studentRepository.InsertAsync(student))
                {
                    var stdCls = await _studentRepository.Filter(c => c.Id == student.Id, c => c.Include(x => x.Class)).FirstOrDefaultAsync();
                    return stdCls.Map<StudentResponse>();
                }
            }
            throw new Exception();
        }

        public async Task<bool> RemoveStudentAsync(Guid stdId)
        {
            var std = await _studentRepository.GetSingleAsync(c => c.Id == stdId);
            if (std != null)
            {
                await _studentRepository.DeleteAsync(std);
                return true;
            }
            return false;
        }

        public async Task<StudentResponse> UpdateStudentAsync(Guid stdId, StudentRequest stdR)
        {
            var std = await _studentRepository.GetSingleAsync(c => c.Id == stdId);
            if (std != null)
            {
                std.ClassId = stdR.ClassId;
                std.StudentName = stdR.StudentName;
                std.Age = stdR.Age;
                if (await _studentRepository.UpdateAsync(std))
                {
                    var stdCls = await _studentRepository.Filter(c => c.Id == std.Id, c => c.Include(x => x.Class)).FirstOrDefaultAsync();
                    return stdCls.Map<StudentResponse>();
                }
            }
            throw new Exception();
        }

        public async Task<PageListContract<StudentResponse>> ListStudentInClassAsync(Guid clsId, PaginationContract pCon)
        {
            var listStudent = _studentRepository.Filter(s => s.ClassId == clsId, c => c.Include(x => x.Class));
            var data = listStudent.ProjectTo<StudentResponse>();
            return await data.Paginate(pCon.PageIndex, pCon.PageSize);
        }
    }
}
