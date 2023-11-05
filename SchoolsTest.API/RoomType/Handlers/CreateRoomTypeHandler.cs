using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.RoomTypes;
using SchoolsTest.WebVers.Pages.Schools;

namespace SchoolsTest.API.RoomType.Handlers;

public class CreateRoomTypeHandler
{
    public static async Task<IResult> Handle(IRepository<Models.RoomType> roomTypeRepository,
        [FromBody] RoomTypeAddDto roomTypeDto,
        [FromRoute] int schoolId)
    {
        var roomType = new Models.RoomType()
        {
            Name = roomTypeDto.Name,
            SchoolId = schoolId,
        };

        await roomTypeRepository.Add(roomType);

        if (roomType is null)
        {
            return Results.NotFound($"RoomType not created");
        }

        return Results.Json(roomType);
        //румтайп створювати схожим до позицій(базові румтайпи та позиції які потім додаються до кожної школи)
        //румтайпи не прив'язані до кожної школи
    }
}
