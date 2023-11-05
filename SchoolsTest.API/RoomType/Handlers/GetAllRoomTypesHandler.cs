using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.RoomType.Handlers;

public class GetAllRoomTypesHandler
{
    public static async Task<IResult> Handle(IRepository<Models.RoomType> roomTypeRepository)
    {
        var roomTypes = await roomTypeRepository.GetAll();

        if (roomTypes is null)
        {
            return Results.NotFound($"RoomTypes not found");
        }

        return Results.Json(roomTypes);
    }
}
