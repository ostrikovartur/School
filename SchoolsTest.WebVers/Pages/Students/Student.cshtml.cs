using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolsTest.WebVers.Pages.Students;

public class StudentModel : BasePageModel
{
    public int SchoolId { get; set; }
    public int Id { get; set; }
    public async Task OnGet(int schoolId, int id)
    {
        SchoolId = schoolId;
        Id = id;
    }
}
