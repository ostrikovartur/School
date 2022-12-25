using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.ConsoleMane;

public class ConsoleLogger : ILogger
{
    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
