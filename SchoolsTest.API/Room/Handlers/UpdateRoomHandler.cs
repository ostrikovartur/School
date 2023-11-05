using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Rooms;

namespace SchoolsTest.API.Room.Handlers;

public class UpdateRoomHandler
{
    public static async Task<IResult> Handle(IRoomRepository roomRepository,
        [FromBody] RoomAddDto roomDto,
        int id)
    {
        var room = await roomRepository.Get(id);

        if (room is null)
        {
            return Results.NotFound($"Room {id} not found");
        }

        room.Number = roomDto.Number;
        //room.RoomTypeIds = roomDto.RoomTypeIds;

        await roomRepository.Update(room);

        return Results.Json(room);
    }
}
