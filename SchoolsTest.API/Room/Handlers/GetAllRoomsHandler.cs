using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Room.Handlers;

public class GetAllRoomsHandler
{
    public static async Task<IResult> Handle(IRoomRepository roomRepository)
    {
        var rooms = await roomRepository.GetAll();
        
        if (rooms is null)
        {
            return Results.NotFound($"Rooms not found");
        }

        return Results.Json(rooms);
    }
}
