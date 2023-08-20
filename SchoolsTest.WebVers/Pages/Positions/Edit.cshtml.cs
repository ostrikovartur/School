using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;

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
    public async Task<IActionResult> OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        Position = await _positionRepository.Get(id);

        if (Position is null)
        {
            return NotFound("Position is not found");
        }

        return Page();
    }
    public async Task<IActionResult> OnPostUpdate(PositionEditDto position)
    {
        var positionToUpdate = await _positionRepository.Get(position.Id);
        if (positionToUpdate is null)
        {
            return NotFound("Position is not found");
        }

        positionToUpdate.Name = position.Name;

        await _positionRepository.Update(positionToUpdate);
        return Redirect($"/positions");
    }

    public async Task<IActionResult> OnPostDelete(PositionEditDto position)
    {
        var positionToUpdate = await _positionRepository.Get(position.Id);
        if (positionToUpdate is null)
        {
            return NotFound("Position is not found");
        }

        await _positionRepository.Delete(positionToUpdate);
        return Redirect($"/positions");
    }
}
