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
        public readonly EfContext context;

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

        public void RemoveStudent(Student student)
        {
            var trackedEntity = context.Students.Local.FirstOrDefault(s => s.Id == student.Id);
            if (trackedEntity == null)
            {
                context.Students.Attach(student);
            }
            var studentToRemove = context.Students.FirstOrDefault(s => s.Id == student.Id);
            context.Students.Remove(studentToRemove);
            Console.WriteLine(studentToRemove.Name+"   sdfsdfdddddddddddddddddddddd");
            context.SaveChanges();
        }
    }
}
