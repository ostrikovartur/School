using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Floors;

public class SelectedFloor : PageModel
{
    public int SchoolId { get; set; }
    public int Id { get; set; }
    public string Message { get; private set; } = "";
    public async Task OnGet(int schoolId, int id)
    {
        SchoolId = schoolId;
        Id = id;
    }
}
