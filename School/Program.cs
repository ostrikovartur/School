using School;
Address malynivka = new()
{
    Country = "Ukraine",
    City = "Malynivka",
    Street = "Вул. Шкільна 1",
    PostalCode = 22360
};

Employee director = new()
{
    FirstName = "Володимир",
    LastName = "Сиченко"
};
Employee mathTeacher = new()
{
    FirstName = "Крисак",
    LastName = "Андрій",
};
School.School malynivskaSchool = new()
{
    Address = malynivka,
    Name = "Малинівська школа #1",
    OpeningDate = new DateOnly(2002, 1, 1),
    Director = director,
};

Floor firstFloor = new()
{
    Number = 1,
};

Floor secondFloor = new()
{
    Number = 2,
};

Floor thirdFloor = new()
{
    Number = 3,
};

Room mathRoom = new()
{
    Number = 101,
    Type = RoomType.Regular | RoomType.Math
};

Room bioRoom = new()
{
    Number = 202,
    Type = RoomType.Regular | RoomType.Biology
};
Room informRoom = new()
{
    Number = 103,
    Type = RoomType.Regular | RoomType.Informatic
};
Room literatureRoom = new()
{
    Number = 204,
    Type = RoomType.Regular | RoomType.Literature
};
Room gymRoom = new()
{
    Number = 300,
    Type = RoomType.Regular | RoomType.Gym
};
Room physicsRoom = new()
{
    Number = 203,
    Type = RoomType.Physics
};
Room hallRoom = new()
{
    Number = 200,
    Type = RoomType.Hall
};

malynivskaSchool.AddFloor(firstFloor);
malynivskaSchool.AddFloor(secondFloor);
malynivskaSchool.AddFloor(thirdFloor);

malynivskaSchool.AddEmployee(mathTeacher);

firstFloor.AddRoom(mathRoom);

firstFloor.AddRoom(informRoom);

secondFloor.AddRoom(bioRoom);

secondFloor.AddRoom(literatureRoom);

thirdFloor.AddRoom(gymRoom);

secondFloor.AddRoom(physicsRoom);

secondFloor.AddRoom(hallRoom);

malynivskaSchool.Print();