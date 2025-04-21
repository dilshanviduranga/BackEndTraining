using StudentManagement.Repository;

namespace StudentManagement.Application
{
    public class UnitOfWork
    {
        public StudentSubjectRepository studentSubjectRepository;
        public SubjectRepository subjectRepository;
        public StudentRepository studentRepository;

        public UnitOfWork(SubjectRepository subjectRepository, StudentRepository studentRepository, StudentSubjectRepository studentSubjectRepository)
        {
            this.studentRepository = studentRepository;
            this.subjectRepository = subjectRepository;
            this.studentSubjectRepository = studentSubjectRepository;
        }

    }
}