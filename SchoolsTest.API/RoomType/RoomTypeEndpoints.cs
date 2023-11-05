using SchoolsTest.API.RoomType.Handlers;
using SchoolsTest.Data.DTOs;
using SchoolsTest.WebVers.Pages.RoomTypes;

namespace SchoolsTest.API.RoomType;

public static class RoomTypeEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/schools/{schoolId:int}/roomTypes")
            .WithTags("RoomTypes Group")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithOpenApi();

        group.MapGet("", GetAllRoomTypesHandler.Handle)
            .WithSummary("Get all room types")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("", CreateRoomTypeHandler.Handle)
            .WithSummary("Create new room type")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("{id}", DeleteRoomTypeHandler.Handle)
            .WithSummary("Delete room type")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("{id}", UpdateRoomTypeHandler.Handle)
            .WithSummary("Update room type")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapGet("{id}", InfoRoomTypeHandler.Handle)
            .WithSummary("Get info about room type")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);
    }
}
