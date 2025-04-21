using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;
using StudentManagement.Repo;

namespace StudentManagement.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EfContext context;

        public StudentRepository(EfContext context)
        {
            this.context = context;
        }

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing the Student Repository...");
        }
    }
}
