using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Employees;

public class TeacherAdd : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<Teacher> _repository;
    public string Message { get; private set; } = "";

    public TeacherAdd(IRepository<Teacher> repository, AppDbContext dbContext)
    {
        _repository = repository;
        _dbcontext = dbContext;
    }
    public void OnGet()
    {
        Message = "Write data about teacher";
    }
    public IActionResult OnPost(string firstName, string lastName, int age)
    {
        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
        {
            return NotFound("School not found");
        }

        if (!int.TryParse(schoolIdStr, out var schoolId))
        {
            return NotFound("Incorrect school Id");
        }
        var currentSchool = _dbcontext.Schools
            .Where(school => school.Id == schoolId)
            .SingleOrDefault();
        Models.Teacher teacher = new(firstName, lastName, age);
        var (valid, error) = currentSchool.AddEmployee(teacher);
        if (valid)
        {
            Message = $"Teacher first and last name:{firstName} {lastName}";
        }
        _dbcontext.SaveChanges();
        return Redirect($"/schools/{schoolId}");
    }
}
