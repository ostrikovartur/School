using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Floors;

public class SelectedFloor : PageModel
{
    public int SchoolId { get; set; }
    public int FloorId { get; set; }
    public string Message { get; private set; } = "";
    public void OnGet(int schoolId, int floorId)
    {
        SchoolId = schoolId;
        FloorId = floorId;
        // get school from db by id;
        //Message = $"School name: {school.Name}";
    }
}
