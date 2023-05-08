using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomsList : PageModel
{
    private readonly IRepository<Room> _repository;
    private readonly IRoomRepository _roomRepository;
    public IEnumerable<Room> Rooms { get; set; }
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public Room Room { get; set; }
    public RoomType RoomType { get; set; }
    public int FloorId { get; set; }
    public int FloorNumber { get; set; }
    public RoomsList(IRepository<Room> repository, IRoomRepository roomRepository)
    {
        _repository = repository;
        _roomRepository = roomRepository;
    }

    public IActionResult OnGet(int floorId, int id)
    {
        FloorId = floorId;
        //Room = _roomRepository.GetRoomWithRoomTypes(id);
        Rooms = _repository.GetAll(r => r.Floor.Id == floorId);

        return Page();
    }
    public IActionResult OnPost(Room room)
    {
        var roomId = room.Id;

        var roomToUpdate = _roomRepository.Get(roomId);
        if (roomToUpdate is null)
        {
            return NotFound("Room is not found");
        }

        roomToUpdate.Number = room.Number;

        roomToUpdate.RoomTypes = room.RoomTypes;

        return Page();
    }
}
