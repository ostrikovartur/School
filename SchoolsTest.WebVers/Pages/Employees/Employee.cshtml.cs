using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolsTest.WebVers.Pages.Employees;

public class Employee : BasePageModel
{
    public int SchoolId { get; set; }
    public int Id { get; set; }
    public void OnGet(int schoolId, int id)
    {
        SchoolId = schoolId;
        Id = id;
    }
}