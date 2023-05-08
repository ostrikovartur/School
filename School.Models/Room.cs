using Newtonsoft.Json;

namespace SchoolsTest.Models;

public class Room : BaseEntity
{
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public int Number { get; set; }
    public int FloorId { get; set; }
    public Floor Floor { get; set; }

    public Room()
    {

    }
    public Room(int number, IEnumerable<RoomType> type, Floor floor)
    {
        Number = number;
        RoomTypes = type;
        Floor = floor;
    }
    public override string ToString()
    {
        return $"Room: {Number}, {RoomTypes}";
    }
}
