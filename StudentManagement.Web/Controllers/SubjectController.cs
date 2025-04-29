using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;
using StudentManagement.Repo;

namespace StudentManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly EfContext _context;

        public SubjectController(EfContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            Subject sub = new Subject(subject.SubjectName);
            _context.Subjects.Add(sub);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubjects), new { id = sub.Id }, sub);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjects(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return AcceptedAtAction(nameof(GetSubjects), new { id = subject.Id }, subject);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }
    }
}
