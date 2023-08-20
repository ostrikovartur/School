using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Schools;

public class AddSchool : PageModel
{
    private readonly IRepository<School> _repository;
    public string Message { get; private set; } = "";

    public AddSchool(IRepository<School> repository)
    {
        _repository = repository;
    }
    public async Task OnGet()
    {
        Message = "Write data about youre school";
    }

    public async Task<IActionResult> OnPost(SchoolAddDto schoolDto/*, AddressDto addressDto*/)
    {
        Address address = new()
        {
            Country = schoolDto.Country,
            City = schoolDto.City,
            Street = schoolDto.Street,
            PostalCode = schoolDto.PostalCode,
        };

        School school = new(schoolDto.Name, address, schoolDto.OpeningDate);
        await _repository.Add(school);
        return Redirect($"/schools");
    }
}
