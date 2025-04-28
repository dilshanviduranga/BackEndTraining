//using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Domain;
using StudentManagement.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using StudentManagement.Web.Dto;


namespace StudentManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentSubjectController : ControllerBase
    {

        public readonly EfContext _context;

        public StudentSubjectController(EfContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<ActionResult<StudentSubject>> PostStudentSubject(StudentSubjectDto dto)
        {
            var student = await _context.Students.FindAsync(dto.StudentId);
            var subject = await _context.Subjects.FindAsync(dto.SubjectId);
            if (student ==null)
            { 
                return BadRequest("Invalid student.");
            }
            else if(subject == null)
            {
                return BadRequest("Invalid subject");
            }
            StudentSubject studentSubject = new StudentSubject(dto.StudentId, dto.SubjectId);


            _context.StudentSubjects.Add(studentSubject);
            await _context.SaveChangesAsync();

            return Created("", studentSubject);
        }


        //[HttpDelete("{id}")]
        //public async Task<ActionResult<StudentSubject>> DeleteStudentSubject(int id)
        //{
        //    var studentSubject = await _context.StudentSubjects.FindAsync(id);
        //    if (studentSubject == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.StudentSubjects.Remove(studentSubject);
        //    await _context.SaveChangesAsync();
        //    return AcceptedAtAction(nameof(GetStudentSubject), new { id = studentSubject.Id }, studentSubject);
        //}


        [HttpGet("get/{id}")]
        public async Task<ActionResult<StudentSubject>> GetStudentSubject(int id)
        {
            var studentSubject = await _context.StudentSubjects.FindAsync(id);

            if (studentSubject == null)
            {
                return NotFound();
            }

            return studentSubject;
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<StudentSubject>> DeleteStudentSubject(int id)
        {
            var studentSubject = await _context.StudentSubjects.FindAsync(id);
            if (studentSubject == null)
            {
                return NotFound();
            }
            _context.StudentSubjects.Remove(studentSubject);
            await _context.SaveChangesAsync();
            return AcceptedAtAction(nameof(GetStudentSubject), new { id = studentSubject.Id }, studentSubject);
        }


        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<StudentSubject>>> GetStudentSubject()
        {
            return await _context.StudentSubjects.ToListAsync();
        }

    }
}
