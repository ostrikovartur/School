using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolsTest.WebVers.Pages.Schools;

public class SelectedSchool : PageModel
{
    public int Id { get; set; }
    public string Message { get; private set; } = "";

    public void OnGet(int id)
    {
        Id = id;
        Response.Cookies.Append("schoolId", Id.ToString());
    }
}