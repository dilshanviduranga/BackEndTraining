using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;

namespace StudentManagement.Repository
{
    public interface IStudentSubjectRepository : IDisposable
    {
        void AddStudentSubject(StudentSubject studentSubject);



    }
}
