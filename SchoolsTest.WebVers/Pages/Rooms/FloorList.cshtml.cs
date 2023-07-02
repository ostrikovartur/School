using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomsOnFloorList : BasePageModel
{
    private readonly IRoomRepository _roomRepository;
    public IEnumerable<Room> Rooms { get; set; }
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public Room Room { get; set; }
    public RoomType RoomType { get; set; }
    public int FloorId { get; set; }
    public int FloorNumber { get; set; }
    public RoomsOnFloorList(IRoomRepository repository, IRoomRepository roomRepository)
    {
        _roomRepository = repository;
        _roomRepository = roomRepository;
    }

    public async Task<IActionResult> OnGetAsync(int floorId)
    {
        FloorId = floorId;
        var schoolId = GetSchoolId();
        if (schoolId == null)
        {
            return Redirect("/schools");
        }
        Rooms = await _roomRepository.GetRoomsWithTypes(schoolId.Value);

        return Page();
    }
    //public IActionResult OnPost(Room room)
    //{
    //    var roomId = room.Id;

    //    var roomToUpdate = _roomRepository.Get(roomId);
    //    if (roomToUpdate is null)
    //    {
    //        return NotFound("Room is not found");
    //    }

    //    roomToUpdate.Number = room.Number;

    //    roomToUpdate.RoomTypes = room.RoomTypes;

    //    return Page();
    //}
}
