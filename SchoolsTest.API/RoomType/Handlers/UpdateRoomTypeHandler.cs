using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.RoomTypes;

namespace SchoolsTest.API.RoomType.Handlers;

public class UpdateRoomTypeHandler
{
    public static async Task<IResult> Handle(IRepository<Models.RoomType> roomTypeRepository, [FromBody] RoomTypeAddDto roomTypeDto, int id)
    {
        var roomType = await roomTypeRepository.Get(id);
        
        if (roomType is null)
        {
            return Results.NotFound($"RoomType {id} not found");
        }

        roomType.Name = roomTypeDto.Name;

        await roomTypeRepository.Update(roomType);

        return Results.Json(roomType);
    }
}
