using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

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

    public async Task<IActionResult> OnGet(int id)
    {
        School = await _repository.GetSchoolWithAddress(id);
        //Director = _directorRepository.Get(id);
        if (School is null)
        {
            return NotFound($"School {id} not found");
        }
        return Page();
    }

    public async Task<IActionResult> OnPostUpdate(SchoolEditDto school)
    {
        //Address address = new()
        //{
        //    Country = addressDto.Country,
        //    City = addressDto.City,
        //    Street = addressDto.Street,
        //    PostalCode = addressDto.PostalCode,
        //};

        var schoolToUpdate = await _repository.Get(school.Id);
        schoolToUpdate.Address = new Address
        {
            Country = school.Country,
            City = school.City,
            Street = school.Street,
            PostalCode = school.PostalCode,
        };
        if (schoolToUpdate is null)
        {
            return NotFound("School is not found");
        }

        //Address address = new()
        //{
        //    Country = addressDto.Country,
        //    City = addressDto.City,
        //    Street = addressDto.Street,
        //    PostalCode = addressDto.PostalCode,
        //};

        schoolToUpdate.Name = school.Name;
        schoolToUpdate.OpeningDate = school.OpeningDate;
        //schoolToUpdate.Address = address;
        schoolToUpdate.Address.Country = school.Country;
        schoolToUpdate.Address.City = school.City;
        schoolToUpdate.Address.Street = school.Street;
        schoolToUpdate.Address.PostalCode = school.PostalCode;

        await _repository.Update(schoolToUpdate);
        return Redirect($"/schools");
    }

    public async Task<IActionResult> OnPostDelete(SchoolEditDto school)
    {
        var schoolToDelete = await _repository.Get(school.Id);
        if (schoolToDelete is null)
        {
            return NotFound("School is not found");
        }

        //schoolToDelete.DeleteDirector();

        schoolToDelete.Employees.Clear();

        await _repository.Delete(schoolToDelete);
        return Redirect($"/schools");
    }
}
