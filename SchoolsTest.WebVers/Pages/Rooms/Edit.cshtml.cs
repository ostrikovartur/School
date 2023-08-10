using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Employees;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class Edit : BasePageModel
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRepository<RoomType> _roomTypeRepository;
    public IEnumerable<Room> Rooms { get; set; }
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public IEnumerable<Floor> Floors { get; set; }
    public RoomDto Room { get; set; }
    public Floor Floor { get; set; }
    //public RoomType RoomType { get; set; }

    public Edit(
        IRoomRepository roomRepository,
        IRepository<RoomType> roomTypeRepository)
    {
        _roomRepository = roomRepository;
        _roomTypeRepository = roomTypeRepository;
    }

    public IActionResult OnGet(int id)
    {
        var schoolId = GetSchoolId();
        if (schoolId == null)
        {
            return Redirect("/floors");
        }

        var room = _roomRepository.GetRoomWithRoomTypes(id);

        if (room is null)
        {
            return NotFound("Room is not found");
        }

        Room = new()
        {
            Id = room.Id,
            Number = room.Number,
            FloorId = room.FloorId,
            RoomTypeIds = room.RoomTypeIds
        };

        RoomTypes = _roomTypeRepository.GetAll();

        return Page();
    }
    public IActionResult OnPostUpdate(RoomDto room)
    {
        var roomToUpdate = _roomRepository.GetRoomWithRoomTypes(room.Id);
        if (roomToUpdate is null)
        {
            return NotFound("Room is not found");
        }
        var floorId = room.FloorId;
        //var currentFloor = _floorRepository.Get(floorId);
        //var floorId = room.FloorId;
        //if (floorId != roomToUpdate.FloorId) 
        //{
        //    var floor = _floorRepository.Get(floorId);
        //    if (floor is not null)
        //    {
        //        roomToUpdate.Floor = floor;
        //    }
        //}

        //roomToUpdate.Number = room.Number;
        //var positions = _positionsRepository.GetAll(p => employeeDto.PositionIds.Contains(p.Id));

        var roomTypes = _roomTypeRepository.GetAll(r => room.RoomTypeIds.Contains(r.Id));

        roomToUpdate.SetNumber(room.Number);
        roomToUpdate.SetFloor(room.FloorId);
        roomToUpdate.SetRoomTypes(roomTypes.ToArray());

        _roomRepository.Update(roomToUpdate);
        return Redirect($"/{floorId}/rooms");
    }

    public IActionResult OnPostDelete(RoomDto room)
    {
        var roomToUpdate = _roomRepository.Get(room.Id);
        if (roomToUpdate is null)
        {
            return NotFound("Room is not found");
        }

        var floorId = room.FloorId;
        //var currentFloor = _floorRepository.Get(floorId);
        //if (floorId != roomToUpdate.FloorId)
        //{
        //    var floor = _floorRepository.Get(floorId);
        //    if (floor is not null)
        //    {
        //        roomToUpdate.Floor = floor;
        //    }
        //}

        _roomRepository.Delete(roomToUpdate);
        return Redirect($"/{floorId}/rooms");
    }
}
