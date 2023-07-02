using Newtonsoft.Json;
using System.Text;

namespace SchoolsTest.Models;

public class Floor : BaseEntity
{
    public int Number { get; set; }
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    public School School { get; set; }
    public int SchoolId { get; set; }


    public Floor()
    {

    }
    public Floor(int number)
        : this(number, new List<Room>())
    {
    }

    [JsonConstructor]

    public Floor(int number, IEnumerable<Room> rooms)
    {
        Number = number;
        Rooms = rooms.ToList();

        foreach (var room in Rooms)
        {
            room.Floor = this;
        }
    }

    public (bool IsValid, string? Error) AddRoom(Room room)
    {
        if (room.Number < 0)
        {
            return (false, "room number must be greater than 0");
        }

        if (Rooms.Any(r => r.Number == Number))
        {
            return (false, "This room number already exists");
        }

        Rooms.Add(room);
        room.Floor = this;
        return (true, null);
    }

    public override string ToString()
    {
        StringBuilder sb = new ();
        sb.AppendLine($"Floor: {Number} Rooms count: {Rooms.Count()}");
        foreach (var room in Rooms)
        {
            sb.AppendLine(room.ToString());
        }
        return sb.ToString();
    }
}
