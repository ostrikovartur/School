namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomAddDto
{
    public int Number { get; set; }
    public int FloorId { get; set; }
    public int[] RoomTypeIds { get; set; } = Array.Empty<int>();
}
