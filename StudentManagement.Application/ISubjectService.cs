using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;

namespace StudentManagement.Application
{
    public interface ISubjectService
    {
        void AddSubject(String sName);
        void ViewSubjects();
    }
}

