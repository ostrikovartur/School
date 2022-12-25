using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Schools;

public class SchoolsList : PageModel
{
    private readonly IRepository<School> _repository;
    public IEnumerable<School> Schools { get; set; }

    public SchoolsList(IRepository<School> repository)
    {
        _repository = repository;
    }

    public void OnGet()
    {
        Schools = _repository.GetAll();
    }
}
