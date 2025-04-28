using System.Text.Json.Serialization;

namespace StudentManagement.Web.Dto
{
    public class StudentDto
    {
        public String studentName;
        public int age;
        public String address;
        //public DateTime dob;

        [JsonConstructor]
        public StudentDto(string studentName, int age, string address)
        {
            this.studentName = studentName;
            this.age = age;
            this.address = address;
            //this.dob = dob;
        }
    }
}
