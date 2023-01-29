using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Floors;

public class Edit : BasePageModel
{
    private readonly IRepository<Floor> _repository;
    public IEnumerable<Floor> Floors { get; set; }
    public IEnumerable<School> Schools { get; set; }
    public School School { get; set; }
    public Floor Floor { get; set; }

    public Edit(IRepository<Floor> repository)
    {
        _repository = repository;
    }
    public IActionResult OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        Floor = _repository.Get(id);

        if (Floor is null)
        {
            return NotFound("Floor is not found");
        }

        return Page();
    }
    public IActionResult OnPostUpdate(Floor floor)
    {
        _repository.Update(floor);
        return Redirect($"/floors");
    }

    public IActionResult OnPostDelete(Floor floor)
    {
        _repository.Delete(floor);
        return Redirect($"/floors");
    }
}
