using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.Positions;

public class Edit : BasePageModel
{
    private readonly IRepository<Position> _positionRepository;
    public IEnumerable<Position> Positions { get; set; }
    public IEnumerable<School> Schools { get; set; }
    public School School { get; set; }
    public Position Position { get; set; }

    public Edit(IRepository<Position> repository)
    {
        _positionRepository = repository;
    }
    public IActionResult OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        Position = _positionRepository.Get(id);

        if (Position is null)
        {
            return NotFound("Position is not found");
        }

        return Page();
    }
    public IActionResult OnPostUpdate(PositionDto position)
    {
        var positionId = position.Id;

        var positionToUpdate = _positionRepository.Get(positionId);
        if (positionToUpdate is null)
        {
            return NotFound("Position is not found");
        }

        positionToUpdate.Name = position.Name;

        _positionRepository.Update(positionToUpdate);
        return Redirect($"/positions");
    }

    public IActionResult OnPostDelete(PositionDto position)
    {
        var positionId = position.Id;

        var positionToUpdate = _positionRepository.Get(positionId);
        if (positionToUpdate is null)
        {
            return NotFound("Position is not found");
        }

        _positionRepository.Delete(positionToUpdate);
        return Redirect($"/positions");
    }
}
