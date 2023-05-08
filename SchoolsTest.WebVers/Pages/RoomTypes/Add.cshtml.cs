using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.RoomTypes;

public class Add : PageModel
{
    AppDbContext _dbcontext;

    public Add(AppDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    public void OnGet()
    {
    }
    public IActionResult OnPost(string name)
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
        Models.RoomType roomType = new(name);
        var (valid, error) = currentSchool.AddRoomType(roomType);
        _dbcontext.SaveChanges();
        return Redirect($"/roomTypes");
    }
}
