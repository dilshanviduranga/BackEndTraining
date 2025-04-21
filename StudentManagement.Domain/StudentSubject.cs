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
    public class StudentSubject
    {
        //private Student student;
        //private Subject subject;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;

        [ForeignKey("Student")]
        public int studentId { get; set; }

        [ForeignKey("Subject")]
        public int subjectId { get; set; }
        public StudentSubject(int studentId, int subjectId)
        {
            this.studentId = studentId;
            this.subjectId = subjectId;
        }

        //public Student Student
        //{
        //    get
        //    {
        //        return student;
        //    }
        //    set
        //    {
        //        student = value;
        //    }
        //}


        //public Subject Subject
        //{
        //    get
        //    {
        //        return subject;
        //    }
        //    set
        //    {
        //        subject = value;
        //    }
        //}
    }
}
