using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomAdd : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<Floor> _repository;
    public IEnumerable<Floor> Floors { get; set; }
    public IDictionary<int, string> RoomType = RoomTypeExt.RoomTypes;
    public string Message { get; private set; } = "";

    public RoomAdd(IRepository<Floor> repository, AppDbContext dbContext)
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
        var floor = _dbcontext.Floors
            .Where(floor => floor.Id == floorId)
            .SingleOrDefault();

        if (floor is null)
        {
            return NotFound("Floor not found");
        }

        RoomType roomType = 0;
        foreach (var rt in roomTypes)
        {
            roomType |= rt;
        }

        var (valid, error) = floor.AddRoom(new Room(roomNumber, roomType, floor));
        if (!valid)
        {
            return BadRequest(error);
        }
        _dbcontext.SaveChanges();
        return Redirect($"/floors/{floorId}/rooms");
    }
}