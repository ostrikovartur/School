using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Floors;

public class FloorAdd : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<School> _repository;
    public IEnumerable<School> Schools { get; set; }
    public string Message { get; private set; } = "";

    public FloorAdd(IRepository<School> repository, AppDbContext dbContext)
    {
        _repository = repository;
        _dbcontext = dbContext;
    }
    public void OnGet()
    {
        Message = "Write data about floor";
        Schools = _repository.GetAll();
    }
    public IActionResult OnPost(int number)
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
        Models.Floor floor = new (number);
        var (valid,error) = currentSchool.AddFloor(floor);
        if (valid)
        {
            Message = $"Floor number:{number}";
        }
        _dbcontext.SaveChanges();
        return Redirect($"/schools/{schoolId}");
    }
}
