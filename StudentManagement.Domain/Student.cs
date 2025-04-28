using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Domain
{
    [PrimaryKey("studentId")]
    public class Student
    {
        [Key]
        private int studentId;

        private String name;
        private int age;
        private DateTime dob;
        private String address;


        public String Name
        {
            get { return name; }
            set { name = value; }

        }

        public int Id
        {
            get { return studentId; }
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

        public Student(int id, String name, int age, DateTime dob, String address)
        {
            this.studentId = id;
            this.name = name;
            this.age = age;
            this.address = address;
        }
    }
}
