using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository
{
    public interface IStudentSubject : IDisposable
    {
        void AddStudentSubject(int studentId, int subjectId);
        //void ViewStudentSubjects();
    }
}
