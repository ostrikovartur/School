using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SchoolsTest.ConsoleMane;
using SchoolsTest.Data;
using SchoolsTest.Models;
using static SchoolsTest.ConsoleMane.Methods;

Console.WriteLine("Welcome to my not finished program");

string dataSource = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Schools";

AppDbContext dbContext = new(dataSource);

//Context Ctx = new();

//var filePath = GetFilePath();

ILogger logger = new ConsoleLogger();

Repository<School> schoolRepository = new(dbContext);
Repository<Floor> floorRepository = new(dbContext);

while (true)
{
    ShowMenu(dbContext);

    var choise = GetMenuChoice();

    if (!choise.HasValue)
    {
        logger.LogError("Wrong choise");
        continue;
    }

    if (choise == Menu.Exit)
    {
        Console.WriteLine("Good Bye!");
        return;
    }

    HandleChoice(choise);
}

void HandleChoice(Menu? choice)
{
    switch (choice)
    {
        case Menu.AddSchool:
            AddSchool();
            break;
        case Menu.SelectSchool:
            SelectSchool();
            break;
        case Menu.AddFloor:
            AddFloor();
            break;
        case Menu.AddRoom:
            AddRoom();
            break;
        case Menu.AddEmployee:
            AddEmployee();
            break;
        case Menu.AddStudent:
            AddStudent();
            break;
        case Menu.ShowAll:
            // show all
            foreach (var school in dbContext.Schools)
            {
                logger.LogInfo(school.ToString());
            }
            break;
        default:
            logger.LogError("Unknown choice");
            break;
    }
}

void AddSchool()
{
    var name = GetValueFromConsole("Enter school name: ");

    var address = GetSchoolAddress();

    var openingDate = GetOpeningDateFromConsole("Enter school opening date: ");

    School school = new(name, address, openingDate, logger);

    schoolRepository.Add(school);
    dbContext.CurrentSchool = school;
    dbContext.SaveChanges();

    Console.WriteLine();
    Console.WriteLine($"School '{school.Name}' successfully added");
    logger.LogInfo(school.ToString());
    Console.WriteLine();

    Address GetSchoolAddress()
    {
        var country = GetValueFromConsole("Enter school country: ");
        var city = GetValueFromConsole("Enter school city or town: ");
        var street = GetValueFromConsole("Enter school street: ");
        var postalCode = GetIntValueFromConsole("Enter school postal code: ");

        return new(country, city, street, postalCode);
    }
}

void SelectSchool()
{
    var schools = schoolRepository.GetAll();

    while (true)
    {
        foreach (var school in schools)
        {
            Console.WriteLine($"{school.Id}: {school.Name}");
        }

        var schoolIndex = GetIntValueFromConsole("Choose school: ");

        if (schoolIndex <= schools.Count())
        {
            //schools.Where(school => school.Id == schoolIndex).SingleOrDefault();
            //dbContext.Schools.Where(s => s.Id == dbContext.CurrentSchool.Id).SingleOrDefault();

            var school = schools.Where(school => school.Id == schoolIndex).SingleOrDefault();
            dbContext.CurrentSchool = school;
            //schoolRepository.CurrentSchool(school);
            break;
        }
        logger.LogError("Please choose correct number from the list above.");
    }
    Console.WriteLine($"Current School: {dbContext.CurrentSchool.Name}");
}

void AddFloor()
{
    var floorNumber = GetIntValueFromConsole("Enter floor number: ");

    Floor floor = new (floorNumber);
    //School school = new(name, address, openingDate, logger);
    var school = dbContext.Schools.Where(s => s.Id == dbContext.CurrentSchool.Id).SingleOrDefault();

    if (school is null)
    {
        logger.LogError($"School '{dbContext.CurrentSchool?.Id}' not found");
        return;
    }


    var (isValid, error) = school.AddFloor(floor);
    if (!isValid)
    {
        logger.LogError(error!);
        return;
    }

    //dbContext.SaveChanges();

    logger.LogInfo($"Floor {floor.Number} added successfully");
    //schoolRepository.AddFloorToCurrentSchool(floor);

    dbContext.CurrentSchool?.ToString();
    dbContext.SaveChanges();
    Console.WriteLine("Floor create");
}

void AddRoom()
{
    while (true)
    {
        var floorNumber = GetIntValueFromConsole("Enter floor number: ");
        var curFloor = dbContext.Floors.Where(f => f.School.Id == dbContext.CurrentSchool.Id && f.Number == floorNumber).SingleOrDefault();
        //var floor = schoolRepository.GetFloor(floorNumber);
        if (curFloor is null)
        {
            logger.LogError($"Floor {floorNumber} does not exists. Either add new floor or enter correct floor number");
            continue;
        }

        var roomNumber = GetIntValueFromConsole("Enter room number: ");
        var roomType = GetRoomTypeFromConsole("Enter room type: ");
        Room room = new(roomNumber,roomType,curFloor);
        //Floor.AddRoom();
        var (isValid, error) = curFloor.AddRoom(room);
        dbContext.SaveChanges();
        //schoolRepository.AddRoomToCurrentSchool(new(roomNumber, roomType, curFloor), curFloor);
        break;
    }

    dbContext.CurrentSchool?.ToString();
    dbContext.SaveChanges();
    Console.WriteLine();
}

void AddEmployee()
{
    var currentSchool = dbContext.Schools
        .Include(t => t.Employees)
        .Where(t => t.Id == dbContext.CurrentSchool.Id)
        .SingleOrDefault();
    var firstName = GetValueFromConsole("Enter employee first name: ");
    var lastName = GetValueFromConsole("Enter employee last name: ");
    var age = GetIntValueFromConsole("Enter employee age: ");

    while (true)
    {
        var type = GetValueFromConsole("If director enter (D/d), if teacher enter (T/t): ").ToUpperInvariant();

        Employee employee = null;

        if (type == "T")
        {
            employee = new Teacher(firstName, lastName, age);
            //var (isValid, error) = currentSchool.AddEmployee(employee);
            //if (!isValid)
            //{
            //    logger.LogError(error);
            //    continue;
            //}
            //if (currentSchool is null)
            //{
            //    return;
            //}
            //dbContext.SaveChanges();
            //break;
        }
        else if (type == "D")
        {
            employee = new Director(firstName, lastName, age);
            //var (isValid, error) = currentSchool.AddEmployee(employee);
            //if (!isValid)
            //{
            //    logger.LogError(error);
            //    continue;
            //}
            //if (currentSchool is null)
            //{
            //    return;
            //}
        }
        else
        {
            logger.LogError("Wrong employee type");
            continue;
        }
        var (isValid,error) = currentSchool!.AddEmployee(employee);
        logger.LogInfo($"Employee {employee.Job} {employee.FirstName} {employee.LastName} with age {employee.Age}");

        //var (isValid, error) = currentSchool.AddEmployee(employee);
        //if (!isValid)
        //{
        //    logger.LogError(error);
        //    continue;
        //}
        //if (school is null)
        //{
        //    return;
        //}
        dbContext.SaveChanges();

        logger.LogInfo($"Employee {firstName} {lastName} successfully added");
        break;
    }


    dbContext.CurrentSchool?.ToString();
    Console.WriteLine();
}
void AddStudent()
{
    var currentSchool = dbContext.Schools
        .Include(t => t.Students)
        .Where(t => t.Id == dbContext.CurrentSchool.Id)
        .SingleOrDefault();
    var firstName = GetValueFromConsole("Enter student first name: ");
    var lastName = GetValueFromConsole("Enter student last name: ");
    var age = GetIntValueFromConsole("Enter student age: ");
    Student student = null;
    student = new Student(firstName, lastName, age);

    var (isValid, error) = currentSchool!.AddStudent(student);
    logger.LogInfo($"Student {student.FirstName} {student.LastName} with age {student.Age}");
    dbContext.SaveChanges();
}