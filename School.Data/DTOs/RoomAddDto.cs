namespace SchoolsTest.WebVers.Pages.Rooms;

public record RoomAddDto
{
    public int Number { get; init; }
    public int FloorId { get; init; }
    public int[] RoomTypeIds { get; init; } = Array.Empty<int>();
}
