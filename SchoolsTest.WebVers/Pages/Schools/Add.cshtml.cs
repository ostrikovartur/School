using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.Schools;

public class AddSchool : PageModel
{
    private readonly IRepository<School> _repository;
    public string Message { get; private set; } = "";

    public AddSchool(IRepository<School> repository)
    {
        _repository = repository;
    }
    public void OnGet()
    {
        Message = "Write data about youre school";
    }

    public IActionResult OnPost(SchoolDto schoolDto, AddressDto addressDto)
    {
        Address address = new()
        {
            Country = addressDto.Country,
            City = addressDto.City,
            Street = addressDto.Street,
            PostalCode = addressDto.PostalCode,
        };

        School school = new(schoolDto.Name, address, schoolDto.OpeningDate);
        _repository.Add(school);
        return Redirect($"/schools");
    }
}
