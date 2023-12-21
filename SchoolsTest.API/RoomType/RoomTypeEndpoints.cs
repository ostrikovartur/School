using SchoolsTest.API.RoomType.Handlers;
using SchoolsTest.Data.DTOs;
using SchoolsTest.Models.Constants;
using SchoolsTest.WebVers.Pages.RoomTypes;

namespace SchoolsTest.API.RoomType;

public static class RoomTypeEndpoints
{
    public static void Map(WebApplication app)
    {
        var manageGroup = app.MapGroup("/schools/{schoolId:int}/roomTypes")
            .WithTags("RoomTypes Group")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.ManageRoomType);
            });

        var infoGroup = app.MapGroup("/schools/{schoolId:int}/roomTypes")
            .WithTags("RoomTypes Group")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.InfoRoomTypes);
            });

        var operateGroup = app.MapGroup("/schools/{schoolId:int}/roomTypes")
            .WithTags("RoomTypes Group")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.OperateRoomTypesInSchool);
            });

        infoGroup.MapGet("", GetAllRoomTypesHandler.Handle)
            .WithSummary("Get all room types")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPost("", CreateRoomTypeHandler.Handle)
            .WithSummary("Create new room type")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapDelete("{id}", DeleteRoomTypeHandler.Handle)
            .WithSummary("Delete room type")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPut("{id}", UpdateRoomTypeHandler.Handle)
            .WithSummary("Update room type")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);

        infoGroup.MapGet("{id}", InfoRoomTypeHandler.Handle)
            .WithSummary("Get info about room type")
            .Produces<RoomTypeDto>()
            .Produces(StatusCodes.Status404NotFound);
    }
}
