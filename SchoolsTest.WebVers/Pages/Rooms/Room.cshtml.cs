using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomModel : PageModel
{
    public int SchoolId { get; set; }
    public int FloorId { get; set; }
    public int Id { get; set; }
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public void OnGet(int schoolId,int floorId, int id)
    {
        SchoolId = schoolId;
        FloorId = floorId;
        Id = id;
    }
}
