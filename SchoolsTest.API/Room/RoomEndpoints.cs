using SchoolsTest.API.Room.Handlers;
using SchoolsTest.Models.Constants;
using SchoolsTest.WebVers.Pages.Rooms;
using SchoolsTest.WebVers.Pages.RoomTypes;

namespace SchoolsTest.API.Room;

public static class RoomEndpoints
{
    public static void Map(WebApplication app)
    {
        var manageGroup = app.MapGroup("/floors/{floorId:int}/rooms")
            .WithTags("Rooms Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.ManageRoom);
            });

        var infoGroup = app.MapGroup("/floors/{floorId:int}/rooms")
            .WithTags("Rooms Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.InfoRoom);
            });

        infoGroup.MapGet("", GetAllRoomsHandler.Handle)
            .WithSummary("Get all rooms")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPost("", CreateRoomHandler.Handle)
            .WithSummary("Create new room")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapDelete("{id}", DeleteRoomHandler.Handle)
            .WithSummary("Delete room")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPut("{id}", UpdateRoomHandler.Handle)
            .WithSummary("Update room")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

        infoGroup.MapGet("{id}", InfoRoomHandler.Handle)
            .WithSummary("Get info about room")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

    }
}
