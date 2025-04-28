using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;
using StudentManagement.Repo;

namespace StudentManagement.Repository
{
    public class SubjectRepository : ISubjectRepository
    {

        public readonly EfContext context;

        public SubjectRepository(EfContext context)
        {
            this.context = context;
        }

        public void AddSubject(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing the Subject Repository...");
        }

        public void DeleteSubject(Subject subject)
        {
            var trackedEntity = context.Students.Local.FirstOrDefault(s => s.Id == subject.Id);
            if (trackedEntity == null)
            {
                context.Subjects.Attach(subject);
            }
            var subjectToRemove = context.Subjects.FirstOrDefault(s => s.Id == subject.Id);
            context.Subjects.Remove(subjectToRemove);
            Console.WriteLine(subjectToRemove.SubjectName + "   sdfsdfdddddddddddddddddddddd");
            context.SaveChanges();
        }
    }
}
