using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Employees;

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
    public async Task<IActionResult> OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        Floor = await _floorRepository.Get(id);

        if (Floor is null)
        {
            return NotFound("Floor is not found");
        }

        return Page();
    }
    public async Task<IActionResult> OnPostUpdate(FloorEditDto floor)
    {
        var floorId = floor.Id;

        var floorToUpdate = await _floorRepository.Get(floorId);
        if (floorToUpdate is null)
        {
            return NotFound("Floor is not found");
        }

        floorToUpdate.Number = floor.Number;

        await _floorRepository.Update(floorToUpdate);
        return Redirect($"/floors");
    }

    public async Task<IActionResult> OnPostDelete(FloorEditDto floor)
    {
        var floorId = floor.Id;

        var floorToDelete = await _floorRepository.Get(floorId);
        if (floorToDelete is null)
        {
            return NotFound("Floor is not found");
        }

        await _floorRepository.Delete(floorToDelete);
        return Redirect($"/floors");
    }
}
