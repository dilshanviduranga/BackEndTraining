using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;

namespace StudentManagement.Repository
{
    public interface IStudentRepository : IDisposable
    {
        void AddStudent(Student student);
    }
}
