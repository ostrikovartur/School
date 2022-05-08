﻿namespace School
{
    class School
    {
        public Address Address { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public DateOnly OpeningDate { get; set; }
        public string Name { get; set; }
        public ICollection<Floor> Floors { get; set; }
        public Employee Director { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public void Print()
        {
            Console.WriteLine($"Name {Name}");
            //for (int i = 0; i < Floors.Count; i++)
            //{
            //    Floor floor = Floors.ElementAt(i);
            //    Console.WriteLine($"Floor  {floor.Number} : {floor.Rooms.Count()}  ");
            //}
            foreach (Floor floor in Floors)
            {
                Console.WriteLine($"Floor:{floor.Number}Rooms:{floor.Rooms.Count()}");
                floor.Print();
            }
        }
    }
    class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
    }
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Room
    {
        public int Number { get; set; }
        public RoomType Type { get; set; }
        public Floor Floor { get; set; }
    }
    class Floor
    {
        public int Number { get; set; }
        private List<Room> _rooms;
        public IEnumerable<Room> Rooms => _rooms;
        public Floor()
        {
            _rooms = new List<Room>();
        }
        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }
        public void Print()
        {
            foreach (Room room in _rooms)
            {
                Console.WriteLine($"Room number:{room.Number}");
                
            }
        }
}
    [Flags]
    enum RoomType
    {
        Regular = 1,
        Math = 2,
        Biology = 4,
        Literature = 8,
        Informatic = 16,
        Gym = 32,
        Physics = 64,
        Hall = 128,
    }
}