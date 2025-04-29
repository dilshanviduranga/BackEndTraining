using Microsoft.AspNetCore.Mvc;
using StudentManagement.Domain;
using StudentManagement.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace StudentManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly EfContext _context;

        public StudentController(EfContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            int id = _context.StudentSubjects.Count() + 1;

            Student s1 = new Student(student.Name , student.Age , student.Dob , student.Address);
            _context.Students.Add(s1);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = s1.Id }, s1);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return AcceptedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }
    }
}
