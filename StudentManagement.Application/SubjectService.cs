using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain;
using StudentManagement.Repository;

namespace StudentManagement.Application
{
    public class SubjectService : ISubjectService
    {


        public static List<Subject> subjectList = new List<Subject>();
        private SubjectRepository subjectRepository;
        private UnitOfWork unitOfWork;

        public List<Subject> SubjectList
        {
            get => subjectList;
            set => subjectList = value;
        }

        //public SubjectService(SubjectRepository subjectRepository)
        //{
        //    this.subjectRepository = subjectRepository;
        //}

        public SubjectService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddSubject(String sName)
        {
            if (subjectList is null)
            {
                subjectList = new List<Subject>();
            }

            foreach (var subject in subjectList)
            {
                if(subject.SubjectName.ToLower() == sName.ToLower().Trim()){
                    Console.WriteLine($"{sName} is already added to the system...\n");
                    return;
                }
            }
            Subject subject1 = new Subject(subjectList.Count + 1, sName.Trim());
            subjectList.Add(subject1);
            Console.WriteLine($"{subject1.SubjectName.Trim()} Subject Successfully Added...\n");
            //subjectRepository.AddSubject(subject1);
            unitOfWork.subjectRepository.AddSubject(subject1);
            return;
        }

        public void ViewSubjects()
        {
            if (subjectList.Count == 0)
            {
                Console.WriteLine("There are no subjects...");
                return;
            }
            Console.WriteLine("Subject Name\n");
            for (int i = 0; i < subjectList.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {subjectList[i].SubjectName}");
            }
            Console.WriteLine();
        }

        public int SelectSubject()
        {
            Console.Write("Enter the ID of the subject:");
            int finder;
            while (true)
            {
                try
                {
                    finder = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Enter a valid input...");
                    continue;
                }
                break;
            }

            if (finder > 0 & finder <= subjectList.Count)
            {
                return finder;
            }
            return -1;
        }
    }
}

