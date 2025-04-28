using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;

namespace StudentManagement.Application
{
    internal interface IAssignService
    {
        void AssignStudentToSubject(int studentId, int subjectId);

        void ViewAssignedList(StudentService studentService , SubjectService subjectService);
    }
}
