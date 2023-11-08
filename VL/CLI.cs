namespace ProjectApp.CLI;

public static class CLI
{
    private static void Print(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    private static void PrintLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintInfo(string message)
    {
        PrintLine(message, ConsoleColor.Blue);
    }
    
    public static void PrintError(string message)
    {
        PrintLine(message, ConsoleColor.Red);
    }
    public static void PrintMenu(string message)
    {
        PrintLine(message, ConsoleColor.Green);
    }
    public static string InputString(string message)
    {
        Print(message,ConsoleColor.Yellow);
        return Console.ReadLine();
    }

    public static void LogToConsole(string message)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}