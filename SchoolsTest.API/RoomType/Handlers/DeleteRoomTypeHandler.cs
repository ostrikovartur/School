using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.RoomType.Handlers;

public class DeleteRoomTypeHandler
{
    public static async Task<IResult> Handle(IRepository<Models.RoomType> roomTypeRepository, int id)
    {
        var roomType = await roomTypeRepository.Get(id);

        if (roomType is null)
        {
            return Results.NotFound($"RoomType {id} not found");
        }

        await roomTypeRepository.Delete(roomType);

        return Results.Ok();
    }
}
