using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.RoomTypes;

public class Add : PageModel
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly AppDbContext _dbContext;

    public Add(ISchoolRepository schoolRepository,
        AppDbContext dbContext)
    {
        _schoolRepository = schoolRepository;
        _dbContext = dbContext;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost(RoomTypeDto roomTypeDto)
    {
        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
        {
            return NotFound("School not found");
        }

        if (!int.TryParse(schoolIdStr, out var schoolId))
        {
            return NotFound("Incorrect school Id");
        }

        var currentSchool = _schoolRepository.Get(schoolId);

        Models.RoomType roomType = new(roomTypeDto.Name);
        var (valid, error) = currentSchool.AddRoomType(roomType);

        _dbContext.SaveChanges();

        return Redirect($"/roomTypes");
    }
}
