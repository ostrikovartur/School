using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Room.Handlers;

public class InfoRoomHandler
{
    public static async Task<IResult> Handle (IRoomRepository roomRepository, int id)
    {
        var room = await roomRepository.Get(id);

        if (room is null)
        {
            return Results.NotFound($"Room {id} not found");
        }

        return Results.Json(room);
    }
}
