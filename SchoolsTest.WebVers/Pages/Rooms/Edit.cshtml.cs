using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class Edit : BasePageModel
{
    private readonly IRepository<Room> _repository;
    public IEnumerable<Room> Rooms { get; set; }

    public IDictionary<int, string> RoomType = RoomTypeExt.RoomTypes;
    public IEnumerable<Floor> Floors { get; set; }
    public Floor Floor { get; set; }
    public Room Room { get; set; }

    public Edit(IRepository<Room> repository)
    {
        _repository = repository;
    }
    public IActionResult OnGet(int id)
    {
        var floorId = GetSchoolId();

        if (floorId == null)
        {
            return Redirect("/floors");
        }

        Room = _repository.Get(id);

        if (Room is null)
        {
            return NotFound("Room is not found");
        }

        return Page();
    }
    //public IActionResult OnPostUpdate(int floorId, int roomNumber, RoomType[] roomTypes)
    //{
    //    var currentFloor = _dbcontext.Floors
    //        .Where(floor => floor.Id == floorId)
    //        .SingleOrDefault();

    //    if (currentFloor is null)
    //    {
    //        return NotFound("Floor not found");
    //    }

    //    RoomType roomType = 0;
    //    foreach (var rt in roomTypes)
    //    {
    //        roomType |= rt;
    //    }

    //    var (valid, error) = currentFloor.AddRoom(new Room(roomNumber, roomType, currentFloor));
    //    if (!valid)
    //    {
    //        return BadRequest(error);
    //    }
    //    _dbcontext.SaveChanges();
    //    return Redirect($"/floors/{floorId}/rooms");
    //}
    public IActionResult OnPostUpdate(Room room)
    {
        _repository.Update(room);
        return Redirect($"/rooms");
    }

    public IActionResult OnPostDelete(Room room)
    {
        _repository.Delete(room);
        return Redirect($"/rooms");
    }
}
