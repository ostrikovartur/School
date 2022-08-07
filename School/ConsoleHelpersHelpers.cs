using System.Text.Json;
using System.Text;
namespace School
{
    internal static class ConsoleHelpersHelpers
    {
        public static void ShowMenu(School? school)
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to perform?");

            Dictionary<Menu, string> menuItems = new()
            {
                { Menu.School, "Create school" },
                { Menu.Floor, "Add floor to the school" },
                { Menu.Room, "Add room to the floor" },
                { Menu.Employee, "Add employee" },
                { Menu.Exit, "Exit" }
            };
            static Menu? GetMenuChoice()
            {
                return Enum.TryParse<Menu>(Console.ReadLine(), out var choice)
                    ? choice
                    : (Menu?)null;
            }

            foreach (var item in menuItems)
            {
                if (item.Key != Menu.School || school is null)
                {
                    Console.WriteLine($"{(int)item.Key}: {item.Value}");
                }
            }
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
        public static string AddInfoInFile(School school)
        {

            //var type = GetValueFromConsole("go to edit the file or fill it again? Write Edit of Fill").ToUpperInvariant();
            string json = JsonSerializer.Serialize(school, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string schoolFileName = @$"{school.Name}.json";
            if (File.Exists(schoolFileName))
            {
                File.Open(desktopFolder, FileMode.Create, FileAccess.Write);
                //Console.WriteLine("go to edit the file or fill it again? Write Edit of Fill");
                //if (type == "Edit")
                //{

                //}
                //if (type == "Fill")
                //{

                //}
            }
            string fullFolder = Path.Combine(desktopFolder, schoolFileName);
            string fileText = File.ReadAllText(fullFolder);
            Console.WriteLine(fileText);

            File.WriteAllText(fullFolder, json);

            if (File.Exists(fullFolder))
            {
                Console.WriteLine("File with school info create!");
            }
            return File.ReadAllText(fullFolder);
        }
    }
}