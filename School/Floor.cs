namespace School
{
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
}