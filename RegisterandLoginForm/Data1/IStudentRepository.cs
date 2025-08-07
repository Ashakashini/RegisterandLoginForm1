using Microsoft.AspNetCore.Mvc;
using RegisterandLoginForm.Models;

namespace RegisterandLoginForm.RegisterandLoginFormDAL
{
    public interface IStudentRepository
    {
        void AddStudentWithQualifications(Student student, List<Qualification> qualifications);
        List<Student> GetAllStudentsWithQualifications();
        Student GetStudentByCredentials(string username, string password); // 👈 Add this
    }
}
