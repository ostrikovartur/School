using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using System.Drawing;

namespace SchoolsTest.WebVers.Pages.Schools;

public class Edit : PageModel
{
    private readonly ISchoolRepository _repository;

    //private readonly IRepository<Director> _directorRepository;
    public School School { get; set; }
    //public Director Director { get; set; }

    public Edit(ISchoolRepository repository /*IRepository<Director> directorRepository*/)
    {
        _repository = repository;
        //_directorRepository = directorRepository;
    }

    public IActionResult OnGet(int id)
    {
        School = _repository.GetSchoolWithAddress(id);
        //Director = _directorRepository.Get(id);
        if (School is null)
        {
            return NotFound($"School {id} not found");
        }
        return Page();
    }

    public IActionResult OnPostUpdate(School school)
    {
        var schoolId = school.Id;

        var schoolToUpdate = _repository.Get(schoolId);
        if (schoolToUpdate is null)
        {
            return NotFound("School is not found");
        }

        schoolToUpdate.Name = school.Name;
        schoolToUpdate.OpeningDate = school.OpeningDate;
        schoolToUpdate.Address = school.Address;

        _repository.Update(schoolToUpdate);
        return Redirect($"/schools");
    }

    public IActionResult OnPostDelete(School school)
    {
        var schoolId = school.Id;

        var schoolToDelete = _repository.Get(schoolId);
        if (schoolToDelete is null)
        {
            return NotFound("School is not found");
        }

        //schoolToDelete.DeleteDirector();

        schoolToDelete.Employees.Clear();

        _repository.Delete(schoolToDelete);
        return Redirect($"/schools");
    }
}
