using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Domain
{
    [PrimaryKey("subjectId")]
    public class Subject
    {
        [Key]
        private int subjectId;

        [Required]
        [MaxLength(100)]
        private String subjectName;


        public Subject() { }
        public Subject(int id, String subjectName)
        {
            this.subjectId = id;
            this.subjectName = subjectName;
        }

        public int SubjectID
        {
            get
            {
                return subjectId;
            }
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



    }
}

