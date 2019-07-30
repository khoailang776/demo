using DemoClass.Contracts;
using DemoClass.Contracts.Student;
using System;
using System.Threading.Tasks;

namespace DemoClass.Services.Student
{
    public interface IStudentService
    {
        // Return
        Task<PageListContract<StudentResponse>> ListStudentInClassAsync(Guid clsId, PaginationContract pCon);
        // Add
        Task<StudentResponse> AddStudentAsync(StudentRequest stdR);
        // Update
        Task<StudentResponse> UpdateStudentAsync(Guid stdId, StudentRequest stdR);
        // Delete
        Task<bool> RemoveStudentAsync(Guid stdId);
    }
}
