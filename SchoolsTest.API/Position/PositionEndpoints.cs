using SchoolsTest.API.Position.Handlers;
using SchoolsTest.Models.Constants;
using SchoolsTest.WebVers.Pages.Positions;

namespace SchoolsTest.API.Position;

public static class PositionEndpoints
{
    public static void Map(WebApplication app)
    {
        var manageGroup = app.MapGroup("/positions")
            .WithTags("Positions Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.ManagePosition);
            });

        var infoGroup = app.MapGroup("/positions")
            .WithTags("Positions Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.InfoPosition);
            });

        var operateGroup = app.MapGroup("/positions")
            .WithTags("Positions Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.OperatePositionsInSchool);
            });

        infoGroup.MapGet("", GetAllPositionsHandler.Handle)
            .WithSummary("Get all positions")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPost("", CreatePositionHandler.Handle)
            .WithSummary("Create new position")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapDelete("{id}", DeletePositionHandler.Handle)
            .WithSummary("Delete position")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPut("{id}", UpdatePositionHandler.Handle)
            .WithSummary("Update position")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

        infoGroup.MapGet("{id}", InfoPositionHandler.Handle)
            .WithSummary("Get info about position")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

    }
}
