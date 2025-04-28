using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;
using StudentManagement.Repository;

namespace StudentManagement.Application
{
    public class AssignService : IAssignService
    {
        private List<StudentSubject> studentSubjectList = new List<StudentSubject>();
        private StudentSubjectRepository studentSubjectRepository;
        private UnitOfWork unitOfWork;

        public List<StudentSubject> StudentSubjectList
        {
            get => studentSubjectList;
            set => studentSubjectList = value;
        }

        //public AssignService(StudentSubjectRepository studentSubjectRepository)
        //{
        //    this.studentSubjectRepository = studentSubjectRepository;
        //}


        public void AssignStudentToSubject(int studentId , int subjectId)
        {
            if (studentSubjectList.Any(x => x.studentId == studentId && x.subjectId == subjectId))
            {
                Console.WriteLine("This student already assigned to this subject...");
                return;
            }
            StudentSubject studentSubject = new StudentSubject(studentId, subjectId);
            studentSubjectList.Add(studentSubject);
            Console.WriteLine("Student assigned to subject successfully...");
            //studentSubjectRepository.AddStudentSubject(studentSubject);

            unitOfWork.studentSubjectRepository.AddStudentSubject(studentSubject);
            //return studentSubject;
        }

        public AssignService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork; 
        }

        public void ViewAssignedList(StudentService studentService , SubjectService subjectService)
        {
            if (studentSubjectList.Count == 0)
            {
                Console.WriteLine("Subjects haven't assigned yet...");
                return;
            }
            Console.WriteLine("\nStudent\t\t|\tSubject\n");
            foreach (var studentSubject in StudentSubjectList)
            {
                Console.WriteLine($"{studentService.StudentList[studentSubject.studentId - 1].Name}\t\t|\t{subjectService.SubjectList[studentSubject.subjectId-1].SubjectName}");
            }
            Console.WriteLine();
        }
    }
}
