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
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Required]
        [MaxLength(100)]
        private String subjectName;

        public Subject(String subjectName)
        {
            this.subjectName = subjectName;
        }

        public String SubjectName
        {
            get
            {
                return subjectName;
            }
            set
            {
                subjectName = value;
            }
        }

        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

        private Subject() { }


    }
}

