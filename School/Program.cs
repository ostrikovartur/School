using School;
Address malynivka = new()
{
    Country = "Ukraine",
    City = "Malynivka",
    Street = "Вул. Шкільна 1",
    PostalCode = 22360
};
Student student = new("Nesteruk", "Michail", 19);

School.School malynivskaSchool = new()
{
    Address = malynivka,
    Name = "Малинівська школа #1",
    OpeningDate = new DateOnly(2002, 1, 1),
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
Room testRoom = new()
{
    Number = 203, 
    Type = RoomType.Test
};

try
{
    malynivskaSchool.AddFloor(firstFloor);
    malynivskaSchool.AddFloor(secondFloor);
    malynivskaSchool.AddFloor(thirdFloor);

    malynivskaSchool.AddDirector("Сиченко", "Володимир", 30);
    malynivskaSchool.AddTeacher("Kuchinska", "Nataliya", 35);
    malynivskaSchool.AddDirector("Fake", "Director", 30);
    malynivskaSchool.AddTeacher("Kuchinska", "Olena", 38);
    malynivskaSchool.AddTeacher("Kuchinska", "Olena", 3);

    firstFloor.AddRoom(mathRoom);
    firstFloor.AddRoom(informRoom);
    secondFloor.AddRoom(bioRoom);
    secondFloor.AddRoom(literatureRoom);
    thirdFloor.AddRoom(gymRoom);
    secondFloor.AddRoom(physicsRoom);
    secondFloor.AddRoom(hallRoom);
    secondFloor.AddRoom(testRoom);

    malynivskaSchool.Print();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
