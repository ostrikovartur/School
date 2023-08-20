namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomEditDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int FloorId { get; set; }
    public int[] RoomTypeIds { get; set; } = Array.Empty<int>();
}
