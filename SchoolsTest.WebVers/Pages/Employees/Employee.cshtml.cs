using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Employees;

public class Employee : BasePageModel
{
    public int SchoolId { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public IEnumerable<Position> Positions { get; set; }
    public async Task OnGetAsync(int schoolId, int id)
    {
        SchoolId = schoolId;
        Id = id;
    }
}
