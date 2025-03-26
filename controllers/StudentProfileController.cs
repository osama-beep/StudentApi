using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.DTOs;
using System.Threading.Tasks;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<StudentProfileDTO>> CreateStudentProfile(CreateStudentProfileDTO profileDTO)
        {
            var studentProfile = new StudentProfile
            {
                FirstName = profileDTO.FirstName,
                LastName = profileDTO.LastName,
                FiscalCode = profileDTO.FiscalCode,
                BirthDate = profileDTO.BirthDate,
                StudentId = profileDTO.StudentId
            };

            _context.StudentProfiles.Add(studentProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentProfile), new { id = studentProfile.Id }, ToDTO(studentProfile));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentProfileDTO>> GetStudentProfile(int id)
        {
            var studentProfile = await _context.StudentProfiles.FindAsync(id);

            if (studentProfile == null)
            {
                return NotFound();
            }

            return ToDTO(studentProfile);
        }

        private static StudentProfileDTO ToDTO(StudentProfile profile)
        {
            return new StudentProfileDTO
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                FiscalCode = profile.FiscalCode,
                BirthDate = profile.BirthDate,
                StudentId = profile.StudentId
            };
        }
    }
}