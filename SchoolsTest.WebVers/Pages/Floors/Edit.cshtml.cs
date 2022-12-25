using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Floors;

public class Edit : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<Floor> _repository;
    public IEnumerable<Floor> Schools { get; set; }
    public Floor Floor { get; set; }
    public string Message { get; private set; } = "";

    public Edit(IRepository<Floor> repository, AppDbContext dbContext)
    {
        _repository = repository;
        _dbcontext = dbContext;
    }
    public void OnGet()
    {
        Schools = _repository.GetAll();
    }
    public IActionResult OnPostSave(Floor floor)
    {
        _repository.Update(floor);
        return Redirect($"/floors");
    }

    public IActionResult OnPostDelete(Floor floor)
    {
        _repository.Delete(floor);
        return Redirect($"/floors");
    }
}
