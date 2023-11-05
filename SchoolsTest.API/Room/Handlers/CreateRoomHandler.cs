using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Employees;
using SchoolsTest.WebVers.Pages.Rooms;
using SchoolsTest.WebVers.Pages.RoomTypes;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SchoolsTest.API.Room.Handlers;

public class CreateRoomHandler
{
    public static async Task<IResult> Handle(
        IRoomRepository _roomRepository,
        IRepository<Models.RoomType> _roomTypeRepository,
        [FromBody] RoomAddDto roomDto,
        [FromRoute] int floorId)
    {
        var roomTypes = await _roomTypeRepository.GetAll(rt => roomDto.RoomTypeIds.Contains(rt.Id));

        if (roomTypes.IsNullOrEmpty())
        {
            roomTypes = new[] { await _roomTypeRepository.Get(RoomTypeDto.BaseRoomTypeId) };
        }

        Models.Room room = new(roomDto.Number, roomTypes.ToArray())
        {
            FloorId = floorId
        };

        await _roomRepository.Add(room);
        
        if (room is null)
        {
            return Results.NotFound($"Room not created");
        }
        //var options = new JsonSerializerOptions
        //{
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};

        return Results.Json(room);
    }
}
