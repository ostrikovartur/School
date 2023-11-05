using SchoolsTest.API.Position.Handlers;
using SchoolsTest.WebVers.Pages.Positions;

namespace SchoolsTest.API.Position;

public static class PositionEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/positions")
            .WithTags("Positions Group")
            .WithOpenApi();

        group.MapGet("", GetAllPositionsHandler.Handle)
            .WithSummary("Get all positions")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("", CreatePositionHandler.Handle)
            .WithSummary("Create new position")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("{id}", DeletePositionHandler.Handle)
            .WithSummary("Delete position")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("{id}", UpdatePositionHandler.Handle)
            .WithSummary("Update position")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapGet("{id}", InfoPositionHandler.Handle)
            .WithSummary("Get info about position")
            .Produces<PositionDto>()
            .Produces(StatusCodes.Status404NotFound);

    }
}
