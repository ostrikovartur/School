using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class Edit : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<Floor> _repository;
    public IEnumerable<Floor> Floors { get; set; }
    public IDictionary<int, string> RoomType = RoomTypeExt.RoomTypes;
    public string Message { get; private set; } = "";

    public Edit(IRepository<Floor> repository, AppDbContext dbContext)
    {
        _repository = repository;
        _dbcontext = dbContext;
    }
    public void OnGet()
    {
        Message = "Write data about room";
        Floors = _repository.GetAll();
    }
    public IActionResult OnPost(int floorId, int roomNumber, RoomType[] roomTypes)
    {
        var currentFloor = _dbcontext.Floors
            .Where(floor => floor.Id == floorId)
            .SingleOrDefault();

        if (currentFloor is null)
        {
            return NotFound("Floor not found");
        }

        RoomType roomType = 0;
        foreach (var rt in roomTypes)
        {
            roomType |= rt;
        }

        var (valid, error) = currentFloor.AddRoom(new Room(roomNumber, roomType, currentFloor));
        if (!valid)
        {
            return BadRequest(error);
        }
        _dbcontext.SaveChanges();
        return Redirect($"/floors/{floorId}/rooms");
    }
}
