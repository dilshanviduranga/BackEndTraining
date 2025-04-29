using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using StudentManagement.Domain;
using StudentManagement.Repository;

namespace StudentManagement.Application
{
    public class StudentService : IStudentService
    {

        public List<Student> studentList = new List<Student>();
        private StudentRepository studentRepository;
        private UnitOfWork unitOfWork;

        public List<Student> StudentList
        {
            get => studentList;
            set => studentList = value;
        }

        public StudentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public void AddStudent(String name, int age, DateTime dob, String address)
        {
            Student student = new Student(name, age, dob, address);
            StudentList.Add(student);
            unitOfWork.studentRepository.AddStudent(student);
            Console.WriteLine($"{student.Name} Student Successfully Added...\n");
        }

        public void ViewStudents()
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("There are no students...");
                return;
            }
            Console.WriteLine("Student Name");
            for (int i = 0; i < StudentList.Count; i++)
            {
                Console.WriteLine($"[{StudentList[i].Id}] {StudentList[i].Name}");
            }
            Console.WriteLine();
        }

        public int SelectStudent()
        {
            Console.Write("Enter the student id of the student:");
            int finder;
            while (true)
            {
                try
                {
                    finder = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Enter a valid input....");
                    continue;
                }
                break;
            }
 
            foreach (var item in studentList)
            {
                if(finder == item.Id)
                {
                    return finder;
                }
            }
            return -1;
        }


        public void DeleteStudent(Student student)
        {
            studentList.Remove(student);
            unitOfWork.studentRepository.RemoveStudent(student);
            Console.WriteLine("Student successfully removed...\n");
        }
    }
}
