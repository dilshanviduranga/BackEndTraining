using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;
using StudentManagement.Repo;

namespace StudentManagement.Repository
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly EfContext context;
        public StudentSubjectRepository(EfContext context)
        {
            this.context = context;
        }
        public void AddStudentSubject(StudentSubject studentSubject)
        {
            context.StudentSubjects.Add(studentSubject);
            context.SaveChanges();
        }

        public void Dispose()
        {
            Console.WriteLine("sfdfsdfsdf");
        }
    }
}
