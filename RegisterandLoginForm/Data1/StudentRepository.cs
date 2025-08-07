using Microsoft.AspNetCore.Mvc;
using RegisterandLoginForm.Data;
using RegisterandLoginForm.Models;
using System.Data.Entity;

namespace RegisterandLoginForm.RegisterandLoginFormDAL 
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddStudentWithQualifications(Student student, List<Qualification> qualifications)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            foreach (var q in qualifications)
            {
                q.StudentId = student.StudentId;
                _context.Qualifications.Add(q);
            }

            _context.SaveChanges();
        }

        public List<Student> GetAllStudentsWithQualifications()
        {
            return _context.Students.Include("Qualifications").ToList();
        }
        public Student GetStudentByCredentials(string username, string password)
        {
            return _context.Students.FirstOrDefault(s => s.Username == username && s.Password == password);
        }
    }
}