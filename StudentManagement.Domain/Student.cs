using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Domain
{
    [PrimaryKey("Id")]
    public class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }
        private String name;
        private int age;
        private DateTime dob;
        private String address;


        public String Name
        {
            get { return name; }
            set { name = value; }

        }

        

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public Student(String name, int age, DateTime dob, String address)
        {
            this.name = name;
            this.name = name;
            this.age = age;
            this.address = address;
        }

        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    }
}
