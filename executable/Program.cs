// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application;
using StudentManagement.Domain;
using StudentManagement.Repo;
using StudentManagement.Repository;

using (EfContext context = new EfContext()) {

    var serviceProvider = new ServiceCollection()
        .AddSingleton<StudentService>()
        .AddSingleton<SubjectService>()
        .AddSingleton<AssignService>()
        .AddSingleton<EfContext>()
        .AddSingleton<StudentRepository>()
        .AddSingleton<SubjectRepository>()
        .AddSingleton<StudentSubjectRepository>()
        .AddSingleton<UnitOfWork>()
        .BuildServiceProvider();

    var studentService = serviceProvider.GetService<StudentService>();
    var subjectService = serviceProvider.GetService<SubjectService>();
    var assignService = serviceProvider.GetService<AssignService>();

    MainLoop(studentService!, subjectService!, assignService!);
    void MainLoop(StudentService studentService, SubjectService subjectService, AssignService assignService)
    {
        context.Database.EnsureCreated();

        studentService.studentList = context.Students.ToList();
        subjectService.SubjectList = context.Subjects.ToList();
        assignService.StudentSubjectList = context.StudentSubjects.ToList();


        while (true)
        {

            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Subject");
            Console.WriteLine("3. Assign Subject To A Student");
            Console.WriteLine("4. View Students List");
            Console.WriteLine("5. View Subject List");
            Console.WriteLine("6. View Subject Assigned List");
            Console.WriteLine("7. Exit\n");
            Console.Write("Enter your option: ");
            int userInput = 0;
            userInput = ValidateIntegerInputs();
            // try
            // {
            //     userInput = Convert.ToInt32(Console.ReadLine());
            // }
            // catch
            // {
            //     Console.WriteLine("Enter a valid number...");
            //     continue;
            // }

            // if(userInput<0 | userInput>3){
            //     Console.WriteLine("Invalid input...");
            // }

            switch (userInput)
            {
                case 1:
                    AddStudent();
                    context.SaveChanges();
                    break;
                case 2:
                    AddSubject();
                    context.SaveChanges();
                    break;
                case 3:
                    AssignSubjectToStudent();
                    context.SaveChanges();
                    break;
                case 4:
                    studentService.ViewStudents();
                    break;
                case 5:
                    subjectService.ViewSubjects();
                    break;
                case 6:
                    assignService.ViewAssignedList(studentService , subjectService);
                    break;
                case 7:
                    Console.WriteLine("Exit...");
                    return;
                default:
                    Console.WriteLine("Try again...");
                    continue;
            }
        }

        int ValidateIntegerInputs()
        {
            int userInput = -1;
            while (true)
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Try again...");
                    Console.Write("Enter your option: ");
                    continue;
                }
                Console.WriteLine();
                return userInput;
            }

        }

        void AssignSubjectToStudent()
        {
            if (studentService.studentList.Count == 0)
            {
                Console.WriteLine("There are no students...");
                return;
            }

            if (subjectService.SubjectList.Count == 0)
            {
                Console.WriteLine("There are no Subjects...");
                return;
            }
            studentService.ViewStudents();
            int studentIndex = studentService.SelectStudent();
            if (studentIndex == -1)
            {
                Console.WriteLine("Not found...");
                return;
            }

            subjectService.ViewSubjects();
            int subjectIndex = subjectService.SelectSubject();
            if (subjectIndex == -1)
            {
                Console.WriteLine("Not found...");
                return;
            }
            //StudentSubject studentSubject = new StudentSubject(studentIndex, subjectIndex);
            assignService.AssignStudentToSubject(studentIndex , subjectIndex);
            
            
            //if (studentSubject == null)
            //{
            //    return;
            //}
            //context.StudentSubjects.Add(studentSubject);


        }

        void AddStudent()
        {
            String name;
            while (true)
            {
                Console.Write("Enter the name:");
                name = Console.ReadLine();
                if (String.IsNullOrEmpty(name) | String.IsNullOrWhiteSpace(name))
                {
                    continue;
                }
                break;
            }
            int age = 0;

            String birthday;
            while (true)
            {
                Console.Write("Enter a date (yyyy-MM-dd): ");
                birthday = Console.ReadLine();
                bool isValid = BirthdayValidation(birthday);

                if (isValid == false)
                {
                    continue;
                }
                break;
            }

            DateTime.TryParse(birthday, out DateTime dob);
            var now = DateTime.Today;
            age = now.Year - dob.Year;

            if (dob.Date > now.AddYears(-age))
            {
                age--;
            }

            String address;
            while (true)
            {
                Console.Write("Enter the address:");
                address = Console.ReadLine();
                if (String.IsNullOrEmpty(address) | String.IsNullOrWhiteSpace(address))
                {
                    continue;
                }
                break;
            }
            studentService.AddStudent(name, age, dob, address);
            //context.Students.Add(student);

        }

        void AddSubject()
        {
            Console.Write("Enter the new subject name:");
            String sName = Console.ReadLine();
            subjectService.AddSubject(sName);
            
        }

        bool BirthdayValidation(string birthday)
        {

            DateTime parsedDate;
            string format = "yyyy-MM-dd";
            bool isValidDate = DateTime.TryParseExact(birthday, format,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out parsedDate);

            if (isValidDate)
            {
                if (DateTime.Now.Year <= parsedDate.Year)
                {
                    Console.WriteLine("Future guy...\n");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Invalid date input.");
                return false;
            }
        }
    }
}