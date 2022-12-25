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
    public void OnGet()
    {
        Message = "Write data about youre school";
    }
    public void OnPost(string name, Address address, DateTime openingDate)
    {
        School school = new(name, address, openingDate);
        _repository.Add(school);
        Redirect($"/schools");
    }
}
