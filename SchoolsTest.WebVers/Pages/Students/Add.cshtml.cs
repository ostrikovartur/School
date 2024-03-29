using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Students;

public class StudentsAdd : PageModel
{
    private readonly IRepository<Student> _studentRepository;
    private readonly ISchoolRepository _schoolRepository;
    private readonly AppDbContext _dbContext;
    
    public string Message { get; private set; } = "";

    public StudentsAdd(IRepository<Student> repository,
        ISchoolRepository schoolRepository,
        AppDbContext dbContext)
    {
        _studentRepository = repository;
        _schoolRepository = schoolRepository;
        _dbContext = dbContext;
    }
    public async Task OnGet()
    {
        Message = "Write data about student";
    }
    public async Task<IActionResult> OnPost(StudentAddDto studentDto)
    {
        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
        {
            return NotFound("School not found");
        }

        if (!int.TryParse(schoolIdStr, out var schoolId))
        {
            return NotFound("Incorrect school Id");
        }
        var currentSchool = await _schoolRepository.Get(schoolId);
        Models.Student student = new(studentDto.FirstName, studentDto.LastName, studentDto.Age);
        var (valid, error) = currentSchool.AddStudent(student);
        if (valid)
        {
            Message = $"Student first and last name:{studentDto.FirstName} {studentDto.LastName}";
        }
        _dbContext.SaveChanges();
        return Redirect($"/students");
    }
}
