using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class Edit : BasePageModel
{
    private readonly IRepository<Room> _roomRepository;
    private readonly IRepository<Floor> _floorRepository;

    public IEnumerable<Room> Rooms { get; set; }

    public IDictionary<int, string> RoomType = RoomTypeExt.RoomTypes;
    public IEnumerable<Floor> Floors { get; set; }
    public Room Room { get; set; }
    public Floor Floor { get; set; }

    public Edit(IRepository<Room> roomRepository, IRepository<Floor> floorRepository)
    {
        _roomRepository = roomRepository;
        _floorRepository = floorRepository;
    }

    public IActionResult OnGet(int id)
    {
        var schoolId = GetSchoolId();
        if (schoolId == null)
        {
            return Redirect("/floors");
        }

        Room = _roomRepository.Get(id);

        if (Room is null)
        {
            return NotFound("Room is not found");
        }

        Floors = _floorRepository.GetAll(f => f.SchoolId == schoolId);

        return Page();
    }
    public IActionResult OnPostUpdate(Room room, RoomType[] roomTypes)
    {
        var roomId = room.Id;

        var roomToUpdate = _roomRepository.Get(roomId);
        if (roomToUpdate is null)
        {
            return NotFound("Room is not found");
        }

        var floorId = room.FloorId;
        if (floorId != roomToUpdate.FloorId) 
        {
            var floor = _floorRepository.Get(floorId);
            if (floor is not null)
            {
                roomToUpdate.Floor = floor;
            }
        }

        roomToUpdate.Number = room.Number;
        RoomType roomType = 0;
        foreach (var rt in roomTypes)
        {
            roomType |= rt;
        }
        roomToUpdate.Type = roomType;

        _roomRepository.Update(roomToUpdate);
        return Redirect($"/{floorId}/rooms");
    }

    public IActionResult OnPostDelete(Room room)
    {
        _roomRepository.Delete(room);
        return Redirect($"/{Floor.Id}/rooms");
    }
}
