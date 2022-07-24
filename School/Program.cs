using School;
using static School.ConsoleHelpers;
using System.Text.Json;
using System.Text;
void PrintMenu()
{
    Console.WriteLine("||====================================");
    Console.WriteLine("||School=Create School");
    Console.WriteLine("||Floor=Add Floor");
    Console.WriteLine("||Room=Add Room");
    Console.WriteLine("||Employee=Add Employee");
    Console.WriteLine("||Exit=Exit");
    Console.WriteLine("||====================================");

    string GetChoice()
    {
        var choise = Console.ReadLine();
        return choise;
    }
    while (true)
    {
        while (true)
        {
            var choise = GetMenuChoice();

            if (!choise.HasValue)
            {
                Console.WriteLine("Wrong choise");
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
                case Menu.School:
                    AddSchool();
                    break;
                case Menu.Floor:
                    AddFloor();
                    break;
                case Menu.Room:
                    AddRoom();
                    break;
                case Menu.Employee:
                    AddEmployee();
                    break;
                    Console.WriteLine("Unknown choice");
                    break;
            }
        }
        void AddFloor()
        {
            var floorNumber = GetIntValueFromConsole("Enter floor number: ");
            Floor floor = new(floorNumber);

            Context.School?.AddFloor(floor);
            Context.School?.Print();
            Console.WriteLine();
            PrintMenu();
        }
        void AddSchool()
        {
            var name = GetValueFromConsole("Enter school name: ");
            //Після відкриття програми шукати файл з назвою школи, якщо знаходить - десеалізувати файл в об'єкт школи та далі працювати з нею, якщо не знаходить - продовжувати заповнення школи
            var address = GetSchoolAddress();

            var openingDate = GetOpeningDateFromConsole("Enter school opening date: ");

            School.School school = new(name, address, openingDate);
            Context.School = school;
            string json = JsonSerializer.Serialize(school);
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string schoolFileName = @$"{school.Name}.txt";
            string fullFolder = Path.Combine(desktopFolder, schoolFileName);

            File.WriteAllText(fullFolder, json);
           
            if (File.Exists(fullFolder))
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!File was create!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            //using (FileStream fstream = new FileStream(fullFolder, FileMode.OpenOrCreate))
            //{
            //    byte[] buffer = Encoding.Default.GetBytes(json);
            //    fstream.Write(buffer, 0, buffer.Length);
            //    Console.WriteLine("Текст записан в файл");
            //}
            Console.WriteLine($"School '{school.Name}' successfully added");
            school.Print();
            Console.WriteLine();
            PrintMenu();
        }

        Address GetSchoolAddress()
        {
            var country = GetValueFromConsole("Enter school country: ");
            var city = GetValueFromConsole("Enter school city or town: ");
            var street = GetValueFromConsole("Enter school street: ");
            var postalCode = GetIntValueFromConsole("Enter school postal code: ");

            return new(country, city, street, postalCode);
        }
        void AddRoom()
        {
            while (true)
            {
                var floorNumber = GetIntValueFromConsole("Enter floor number: ");
                var floor = Context.School?.Floors.FirstOrDefault(f => f.Number == floorNumber);

                if (floor is null)
                {
                    Console.WriteLine($"Floor {floorNumber} does not exists. Either add new floor or enter correct floor number");
                    continue;
                }

                var roomNumber = GetIntValueFromConsole("Enter room number: ");
                var roomType = GetRoomTypeFromConsole("Enter room type: ");

                floor.AddRoom(new(roomNumber, roomType, floor));
                break;
            }

            Context.School?.Print();
            Console.WriteLine();
            PrintMenu();
        }

        Context.School?.Print();
        Console.WriteLine();
        void AddEmployee()
        {
            var firstName = GetValueFromConsole("Enter employee first name: ");
            var lastName = GetValueFromConsole("Enter employee last name: ");
            var age = GetIntValueFromConsole("Enter employee age: ");

            while (true)
            {
                var type = GetValueFromConsole("If director enter (D/d), if teacher enter (T/t): ").ToUpperInvariant();

                if (type == "T")
                {
                    Context.School?.AddTeacher(firstName, lastName, age);
                    break;
                }
                else if (type == "D")
                {
                    Context.School?.AddDirector(firstName, lastName, age);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong employee type");
                }
            }
            Context.School?.Print();
            Console.WriteLine();
            PrintMenu();
        }
        void Exit()
        {
            Console.WriteLine("Good luck!");
            return;
        }

    }
}
PrintMenu();