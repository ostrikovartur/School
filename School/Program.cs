using School;
Adress malynivka = new()
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
void PrintMenu()
{
    Console.WriteLine("||====================================");
    Console.WriteLine("||Hello, what you want do? Choice!");
    Console.WriteLine("||School=Create School");
    Console.WriteLine("||Adress=Create Adress for School");
    Console.WriteLine("||Floor=Add Floor");
    Console.WriteLine("||Room=Add Room");
    Console.WriteLine("||Employee=Add Employee");
    Console.WriteLine("||Exit=Exit");
    Console.WriteLine("||====================================");
}
string GetChoice()
{
    var choise = Console.ReadLine();
    return choise;
}

void Action(string choise)
{
    while(true)
    {
        if (choise == "Floor")
        {
            Console.WriteLine("What's number floor?");
            Floor floor = new Floor()
            {
                Number = Convert.ToInt32(Console.ReadLine())
            };
            Console.WriteLine($"You create new floor with number |{floor.Number}|");
            return;

        }
        if (choise == "School")
        {
            Console.WriteLine($"What's name of school?");
            School.School school = new()
            {
                Name = Console.ReadLine(),
                 = 
            };
            Console.WriteLine($"School name is |{school.Name}|");
            Console.WriteLine("Which country of school?");
            Console.WriteLine("School has been created");
            return;
        }
        if (choise == "Adress")
        {
            Console.WriteLine("Which country of your school");
            Adress adress = new Adress()
            {
                Country = Console.ReadLine(),

            };
        }
        if (choise == "Room")
        {
            Console.WriteLine("What's room number");
            Room room = new Room()
            {
                Number = Convert.ToInt32(Console.ReadLine()),
                //Type = 
            };
        }
    }
}
PrintMenu();
string choice = GetChoice();

if (choice == "Exit")
{
    Console.WriteLine("Good luck!");
    return;
}

Action(choice);
while (true)
{
    //Console.WriteLine("||====================================");
    //Console.WriteLine("||Hello, what you want do? Choice!");
    //Console.WriteLine("||School=Create School");
    //Console.WriteLine("||Floor=Add Floor");
    //Console.WriteLine("||Room=Add Room");
    //Console.WriteLine("||Employee=Add Employee");
    //Console.WriteLine("||Exit=Exit");
    //Console.WriteLine("||====================================");
    var choise = Console.ReadLine();
    if (choise == "Exit")
    {
        Console.WriteLine("Good luck!");
        break;
    }
    if (choise == "Floor")
    {
        Console.WriteLine("What's number floor?");
        Floor floor = new Floor()
        {
            Number = Convert.ToInt32(Console.ReadLine())
        };
    }
    if (choise == "Room")
    {
        Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("What's room number");
    }
    if (choise == "School")
    {
        Console.WriteLine("What's name of school?");
        
    }
    if (choise == "Employee")
    {
        Console.WriteLine("What's type of Employee? Choise!");
        Console.WriteLine("1=Director");
        Console.WriteLine("2=Teacher");
        if (choise == "1")
        {
            Console.WriteLine("What's name of Director?");
        }
        if (choise == "2")
        {
            Console.WriteLine("What's name of Teacher?");
        }
    }
}