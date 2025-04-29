using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;

namespace StudentManagement.Application
{
    public interface IStudentService
    {
        void AddStudent(String name, int age, DateTime dob, String address);
        void ViewStudents();

        void DeleteStudent(Student student);
    }
}
