using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Floors;

public class FloorsList : PageModel
{
    private readonly IRepository<Floor> _repository;
    public IEnumerable<Floor> Floors { get; set; }

    public FloorsList(IRepository<Floor> repository)
    {
        _repository = repository;
    }

    public IActionResult OnGet()
    {
        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
        {
            return NotFound("School not found");
        }

        if (!int.TryParse(schoolIdStr, out var schoolId))
        {
            return NotFound("Incorrect school Id");
        }

        Floors = _repository.GetAll(f => f.School.Id == schoolId);
        return Page();
        //Cookie? email = cookies.GetCookies(uri).FirstOrDefault(c => c.Name == "email");
    }
}
