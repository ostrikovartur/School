using School;


Address malynivka = new Address
{
    Country = "Ukraine",
    City = "Malynivka",
    Street = "Вул. Шкільна 1",
    PostalCode = 22360
};

Employee director = new Employee
{
    FirstName = "Володимир",
    LastName = "Сиченко"
};

School.School malynivskaSchool = new School.School
{
    Address = malynivka,
    Name = "Малинівська школа #1",
    OpeningDate = new DateOnly(2002, 1, 1),
    Floors = new List<Floor>(),
    Rooms = new List<Room>(),
    Director = director,
    Employees = new List<Employee>()
};

Floor firstFloor = new Floor
{
    Number = 1,
    Rooms = new List<Room>()
};

malynivskaSchool.Floors.Add(firstFloor);

Floor secondFloor = new Floor
{
    Number = 2,
    Rooms = new List<Room>()
};
malynivskaSchool.Floors.Add(secondFloor);

Floor thirdFloor = new Floor
{
    Number = 3,
    Rooms = new List<Room>()
};
malynivskaSchool.Floors.Add(thirdFloor);

Room mathRoom = new Room
{
    Number = 101,
    Type = RoomType.Regular | RoomType.Math,
    Floor = firstFloor
};

Room bioRoom = new Room
{
    Number = 202,
    Type = RoomType.Regular | RoomType.Biology,
    Floor = secondFloor
};
Room informRoom = new Room
{
    Number = 103,
    Type = RoomType.Regular | RoomType.Informatic,
    Floor = firstFloor
};
Room literatureRoom = new Room
{
    Number = 204,
    Type = RoomType.Regular | RoomType.Literature,
    Floor = secondFloor
};
Room gymRoom = new Room
{
    Number = 100,
    Type = RoomType.Regular | RoomType.Gym,
    Floor = thirdFloor
};
Room physicsRoom = new Room
{
    Number = 203,
    Type = RoomType.Physics,
    Floor = secondFloor
};
Room hallRoom = new Room
{
    Number = 200,
    Type = RoomType.Hall,
    Floor = secondFloor
};


malynivskaSchool.Rooms.Add(mathRoom);
malynivskaSchool.Rooms.Add(bioRoom);
malynivskaSchool.Rooms.Add(informRoom);
malynivskaSchool.Rooms.Add(literatureRoom);
malynivskaSchool.Rooms.Add(gymRoom);
malynivskaSchool.Rooms.Add(physicsRoom);
malynivskaSchool.Rooms.Add(hallRoom);

firstFloor.Rooms.Add(mathRoom);

firstFloor.Rooms.Add(informRoom);

secondFloor.Rooms.Add(bioRoom);

secondFloor.Rooms.Add(literatureRoom);

thirdFloor.Rooms.Add(gymRoom);

secondFloor.Rooms.Add(physicsRoom);

secondFloor.Rooms.Add(hallRoom);

    //class Malynovska
    //{
    //    string officialName = "Малинівська школа #1";
    //    string address = "Вул. Шкільна 1";
    //    int Floors = 2;
    //    int yearOfOpening = 2002;
    //}
    //class Math
    //{
    //    int maxPupils = 15;
    //    int Dimensions = 5; //розміри у метрах квадратних
    //    string Floor = Floor2;
    //}
    //class Hall
    //{
    //    int maxPupils = 80;
    //    int Dimensions = 15;
    //    string Floor = Floor2;
    //}
    //class Medical
    //{
    //    public int maxPupils = 5;
    //    public int Dimensions = 3;
    //    public string Floor = Floor2;
    //}
    //class Dining
    //{
    //    public int maxPupils = 30;
    //    public int Dimensions = 10;
    //    public string Floor = Floor1;
    //}
    //class Floor1
    //{
    //    int Dimensions = 40;
    //}
    //class Floor2
    //{
    //    int Dimensions = 40;
    //}
//}
