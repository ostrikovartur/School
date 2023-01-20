using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Floors;

public class Edit : PageModel
{
    private readonly IRepository<Floor> _repository;
    public IEnumerable<Floor> Floors { get; set; }
    public School School { get; set; }
    //public IEnumerable<Floor> Floors { get; set; }
    public Floor Floor { get; set; }

    public Edit(IRepository<Floor> repository)
    {
        _repository = repository;
    }
    public void OnGet(var sId)
    {
        Floors = _repository.GetAll();
        sId = HttpContext.Request.Cookies["SchoolId"];
    }
    public IActionResult OnPostUpdate(Floor floor)
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
