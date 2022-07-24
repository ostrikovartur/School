using School;

namespace SchoolMgmnt;

public static class ConsoleHelpers
{
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
        RoomType roomType;

        while (true)
        {
            ShowRoomTypes();
            var strValue = GetValueFromConsole(message);

            if (Enum.TryParse<RoomType>(strValue, out roomType))
            {
                return roomType;
            }
            Console.WriteLine($"Incorrect room type: {strValue}");
        }

        void ShowRoomTypes()
        {
            foreach (var type in RoomTypeExt.RoomTypes)
            {
                Console.WriteLine($"{type.Key} - {type.Value}");
            }

            Console.WriteLine("Please choose the room type. If there could be more than one type you combine them by adding numbers. For example: 'Regular' and 'Biology' will be 1 + 4 = 5");
        }
    }

    public static DateOnly GetOpeningDateFromConsole(string message)
    {
        DateOnly openingDate;

        while (true)
        {
            var strValue = GetValueFromConsole(message);

            if (DateOnly.TryParse(strValue, out openingDate))
            {
                break;
            }
            Console.WriteLine($"{strValue} is not correct date format. Try 'YYYY-MM-DD'");
        }
        return openingDate;
    }
}