using SchoolsTest.Models;

namespace SchoolsTest.ConsoleMane;

public static class Methods
{
    public static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("What do you want to perform?");

        Dictionary<Menu, string> menuItems = new()
        {
            { Menu.AddSchool, "Create school" },
            { Menu.SelectSchool, "Select school" },
            { Menu.AddFloor, "Add floor to the school" },
            { Menu.AddRoom, "Add room to the floor" },
            { Menu.AddEmployee, "Add employee" },
            { Menu.ShowAll, "Show all information" },
            { Menu.Exit, "Exit" }
        };

        foreach (var item in menuItems)
        {
            Console.WriteLine($"{(int)item.Key}: {item.Value}");
        }
    }
    public static Menu? GetMenuChoice()
    {
        return Enum.TryParse<Menu>(Console.ReadLine(), out var choice)
            ? choice
            : (Menu?)null;
    }

    public static string GetValueFromConsole(string message)
    {
        string? consoleValue;
        while (true)
        {
            Console.Write(message);
            consoleValue = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(consoleValue))
            {
                break;
            }
        }
        return consoleValue;
    }
    public static int GetIntValueFromConsole(string message)
    {
        int intValue;
        while (true)
        {
            var strValue = GetValueFromConsole(message);
            if (int.TryParse(strValue, out intValue))
            {
                break;
            }
            Console.WriteLine($"{strValue} is not correct number");
        }
        return intValue;
    }


    public static RoomType GetRoomTypeFromConsole(string message)
    {
        //RoomType roomType;

        //while (true)
        //{
        //    ShowRoomTypes();
        //    var strValue = GetValueFromConsole(message);

        //    if (Enum.TryParse(strValue, out roomType))
        //    {
        //        return roomType;
        //    }
        //    Console.WriteLine($"Incorrect room type: {strValue}");
        //}

        //void ShowRoomTypes()
        //{
        //    foreach (var type in RoomTypeExt.RoomTypes)
        //    {
        //        Console.WriteLine($"{type.Key} - {type.Value}");
        //    }

        //    Console.WriteLine("Please choose the room type. If there could be more than one type you combine them by adding numbers. For example: 'Regular' and 'Biology' will be 1 + 4 = 5");
        //}
        return null;
    }

    public static DateTime GetOpeningDateFromConsole(string message)
    {
        DateTime openingDate;

        while (true)
        {
            var strValue = GetValueFromConsole(message);

            if (DateTime.TryParse(strValue, out openingDate))
            {
                break;
            }
            Console.WriteLine($"{strValue} is not correct date format. Try 'YYYY-MM-DD'");
        }
        return openingDate;
    }
}
