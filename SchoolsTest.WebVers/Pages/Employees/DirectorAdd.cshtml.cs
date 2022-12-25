using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Employees;

public class DirectorAdd : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<Director> _repository;
    public string Message { get; private set; } = "";

    public DirectorAdd(IRepository<Director> repository, AppDbContext dbContext)
    {
        _repository = repository;
        _dbcontext = dbContext;
    }
    public void OnGet()
    {
        Message = "Write data about director";
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
        Models.Director director = new(firstName, lastName, age);
        var (valid, error) = currentSchool.AddEmployee(director);
        if (director != null)
        {
            //error = "Director already exist";
            
        }
        _dbcontext.SaveChanges();
        return Redirect($"/schools/{schoolId}");
    }
}
