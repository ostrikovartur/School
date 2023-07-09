using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class Edit : BasePageModel
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRepository<Floor> _floorRepository;
    private readonly IRepository<RoomType> _roomTypeRepository;
    public IEnumerable<Room> Rooms { get; set; }
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public IEnumerable<Floor> Floors { get; set; }
    public Room? Room { get; set; }
    public Floor Floor { get; set; }
    public RoomType RoomType { get; set; }

    public Edit(
        IRoomRepository roomRepository,
        IRepository<Floor> floorRepository,
        IRepository<RoomType> roomTypeRepository)
    {
        _roomRepository = roomRepository;
        _floorRepository = floorRepository;
        _roomTypeRepository = roomTypeRepository;
    }

    public IActionResult OnGet(int id)
    {
        var schoolId = GetSchoolId();
        if (schoolId == null)
        {
            return Redirect("/floors");
        }

        Room = _roomRepository.GetRoomWithRoomTypes(id);

        if (Room is null)
        {
            return NotFound("Room is not found");
        }

        Floors = _floorRepository.GetAll(f => f.SchoolId == schoolId);
        RoomTypes = _roomTypeRepository.GetAll();

        return Page();
    }
    public IActionResult OnPostUpdate(Room room)
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

        roomToUpdate.RoomTypes = room.RoomTypes;

        _roomRepository.Update(roomToUpdate);
        return Redirect($"/{floorId}/rooms");
    }

    public IActionResult OnPostDelete(Room room)
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

        _roomRepository.Delete(roomToUpdate);
        return Redirect($"/{floorId}/rooms");
    }
}
