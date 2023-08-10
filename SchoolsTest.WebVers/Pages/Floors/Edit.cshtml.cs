using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Employees;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.Floors;

public class Edit : BasePageModel
{
    private readonly IRepository<Floor> _floorRepository;
    public IEnumerable<Floor> Floors { get; set; }
    public IEnumerable<School> Schools { get; set; }
    public School School { get; set; }
    public Floor Floor { get; set; }

    public Edit(IRepository<Floor> repository)
    {
        _floorRepository = repository;
    }
    public IActionResult OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        Floor = _floorRepository.Get(id);

        if (Floor is null)
        {
            return NotFound("Floor is not found");
        }

        return Page();
    }
    public IActionResult OnPostUpdate(FloorDto floor)
    {
        var floorId = floor.Id;

        var floorToUpdate = _floorRepository.Get(floorId);
        if (floorToUpdate is null)
        {
            return NotFound("Floor is not found");
        }

        floorToUpdate.Number = floor.Number;

        _floorRepository.Update(floorToUpdate);
        return Redirect($"/floors");
    }

    public IActionResult OnPostDelete(FloorDto floor)
    {
        var floorId = floor.Id;

        var floorToDelete = _floorRepository.Get(floorId);
        if (floorToDelete is null)
        {
            return NotFound("Floor is not found");
        }

        _floorRepository.Delete(floorToDelete);
        return Redirect($"/floors");
    }
}
