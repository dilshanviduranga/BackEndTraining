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

        private readonly EfContext context;

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
    }
}
