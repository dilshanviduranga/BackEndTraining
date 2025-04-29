using System.Text.Json.Serialization;

namespace StudentManagement.Web.Dto
{
    public class SubjectDto
    {
        public String subName;

        [JsonConstructor]
        public SubjectDto(string subName)
        {
            this.subName = subName;
        }
    }
}
