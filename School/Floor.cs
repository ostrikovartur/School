namespace School;

class Floor
{
    public int Number { get; set; }
    public List<Room> _rooms;
    public IEnumerable<Room> Rooms => _rooms;
    public Floor()
    {
        _rooms = new List<Room>();
    }
    public void AddRoom(Room room)
    {
        Console.WriteLine("=========Room to add:===========");
        Console.WriteLine($"Adding room:{room.Type} with number {room.Number}");
        if (room.Number < 0)
        {
            Console.WriteLine("Error(Room number don't write)");
            return;
        }
        for (int i = 0; i < _rooms.Count; i++)
        {
            var rom = _rooms[i];
            if (rom.Number == room.Number)
            {
                Console.WriteLine("Error(This number already used)");
                return;
            }
        }
        _rooms.Add(room);
        room.Floor = this;
    }
    public void Print()
    {
        Console.WriteLine($"Floor:{Number}, Rooms:{Rooms.Count()}");
        foreach (Room room in _rooms)
        {
            room.Print();
        }
    }
}
