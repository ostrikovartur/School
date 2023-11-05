﻿using SchoolsTest.API.Room.Handlers;
using SchoolsTest.WebVers.Pages.Rooms;
using SchoolsTest.WebVers.Pages.RoomTypes;

namespace SchoolsTest.API.Room;

public static class RoomEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/floors/{floorId:int}/rooms")
            .WithTags("Rooms Group")
            .WithOpenApi();

        group.MapGet("", GetAllRoomsHandler.Handle)
            .WithSummary("Get all rooms")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("", CreateRoomHandler.Handle)
            .WithSummary("Create new room")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("{id}", DeleteRoomHandler.Handle)
            .WithSummary("Delete room")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("{id}", UpdateRoomHandler.Handle)
            .WithSummary("Update room")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapGet("{id}", InfoRoomHandler.Handle)
            .WithSummary("Get info about room")
            .Produces<RoomDto>()
            .Produces(StatusCodes.Status404NotFound);

    }
}