using Newtonsoft.Json;
using System.Text;

namespace SchoolsTest.Models;

public class Floor : ILogger
{
    public int Number { get; set; }

    private readonly List<Room> _rooms;
    public IEnumerable<Room> Rooms => _rooms;

    public ILogger _logger;
    public void SetLogger(ILogger logger)
    {
        _logger = logger;
    }
    public void LogInfo(string message) => Console.WriteLine(message);
    public void LogError(string message) => Console.WriteLine(message);
    public Floor(int number, ILogger logger)
        : this(number, new List<Room>())
    {
        SetLogger(logger);
    }

    [JsonConstructor]

    public Floor(int number, IEnumerable<Room> rooms)
    {
        Number = number;
        _rooms = rooms.ToList();

        foreach (var room in _rooms)
        {
            room.Floor = this;
        }
    }

    public void AddRoom(Room room)
    {
        if (room.Number < 0)
        {
            _logger.LogError("room number must be greater than 0");
            return;
        }

        for (int i = 0; i < _rooms.Count; i++)
        {
            Room r = _rooms[i];
            if (r.Number == room.Number)
            {
                _logger.LogError("This room number already exists");
                return;
            }
        }

        _rooms.Add(room);
        room.Floor = this;
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
