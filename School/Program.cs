using SchoolsTest.ConsoleMane;
using SchoolsTest.Data;
using SchoolsTest.Models;
using static SchoolsTest.ConsoleMane.Methods;

Console.WriteLine("Welcome to my not finished program");

Context Ctx = new();

var filePath = GetFilePath();

ILogger logger = new ConsoleLogger();

SchoolRepository schoolRepository = new(Ctx, filePath, logger);

while (true)
{
    ShowMenu(Ctx);

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
        case Menu.ShowAll:
            // show all
            foreach (var school in Ctx.Schools)
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

    schoolRepository.AddSchool(school);

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
    var schools = schoolRepository.GetSchools().ToArray();

    while (true)
    {
        for (var i = 0; i < schools.Length; i++)
        {
            Console.WriteLine($"{i}: {schools[i].Name}");
        }
        var schoolIndex = GetIntValueFromConsole("Choose school: ");

        if (schoolIndex < schools.Length)
        {
            schoolRepository.SetCurrentSchool(schools[schoolIndex]);
            break;
        }
        logger.LogError("Please choose correct number from the list above.");
    }
}
void AddFloor()
{
    var floorNumber = GetIntValueFromConsole("Enter floor number: ");

    schoolRepository.AddFloorToCurrentSchool(new(floorNumber,logger));//!!!!

    Ctx.CurrentSchool?.ToString();
    Console.WriteLine();
}

void AddRoom()
{
    while (true)
    {
        var floorNumber = GetIntValueFromConsole("Enter floor number: ");

        var floor = schoolRepository.GetFloor(floorNumber);
        if (floor is null)
        {
            logger.LogError($"Floor {floorNumber} does not exists. Either add new floor or enter correct floor number");
            continue;
        }

        var roomNumber = GetIntValueFromConsole("Enter room number: ");
        var roomType = GetRoomTypeFromConsole("Enter room type: ");
        schoolRepository.AddRoomToCurrentSchool(new(roomNumber, roomType, floor), floor);
        break;
    }

    Ctx.CurrentSchool?.ToString();
    Console.WriteLine();
}

void AddEmployee()
{
    var firstName = GetValueFromConsole("Enter employee first name: ");
    var lastName = GetValueFromConsole("Enter employee last name: ");
    var age = GetIntValueFromConsole("Enter employee age: ");

    while (true)
    {
        var type = GetValueFromConsole("If director enter (D/d), if teacher enter (T/t), if student enter (S/s): ").ToUpperInvariant();

        if (type == "T")
        {
            schoolRepository.AddEmployeeToCurrentSchool(new Teacher(firstName, lastName, age, logger));
            break;
        }
        else if (type == "D")
        {
            schoolRepository.AddEmployeeToCurrentSchool(new Director(firstName, lastName, age, logger));
            break;
        }
        //else if (type == "S")
        //{
        //    schoolRepository.AddEmployeeToCurrentSchool(new Student(firstName, lastName, age));
        //    break;
        //}
        else
        {
            logger.LogError("Wrong employee type");
        }
    }

    Ctx.CurrentSchool?.ToString();
    Console.WriteLine();
}

string GetFilePath()
{
    var fileName = GetValueFromConsole("Enter storage file name: ");
    var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    var fullPath = Path.Combine(desktopFolder, fileName);

    return fullPath;
}