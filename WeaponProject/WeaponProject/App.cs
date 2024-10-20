namespace WeaponProject;

internal class App
{
    public static void MainPage()
    {
        HeaderMsg("Valid commands");
        Console.WriteLine("0 -> To get information about weapon");
        Console.WriteLine("1 -> To open fire");
        Console.WriteLine("2 -> Open fire until the entire magazine is empty");
        Console.WriteLine("3 -> Shows the number of bullets required to fill the magazine");
        Console.WriteLine("4 -> Reloads the magazine");
        Console.WriteLine("5 -> Change fire mode");
        ErrorMsg("6 -> To exit the application\n");
    }

    public static void InfoPage(Weapon weapon)
    {
        HeaderMsg("About The Weapon");
        Console.WriteLine($"Capacity of bullet: {weapon.CapacityOfBullet}");
        Console.WriteLine($"Number of bullets: {weapon.NumberOfBullets}");
        Console.WriteLine($"Fire mode: {weapon.FireMode}");
        ErrorMsg("[M] -> Go to Main page");
        ErrorMsg("6 -> To exit the application\n");
        string input = InfiniteInput(["M", "6"], errorMessage: "There is no such command!", isUpper: true);
        Console.Clear();

        if (input == "M") return;
        else if (input == "6") Environment.Exit(0);
    }

    public static string InfiniteInput(string[] expected, string message = "", string errorMessage = "", bool isUpper = false)
    {
        string input = "";
        while (true)
        {
            Console.Write(message);
            input = isUpper ?
                Console.ReadLine().Trim().ToUpper() :
                Console.ReadLine().Trim();
            if (expected.Contains(input)) { break; }
            if (errorMessage.Trim().Length > 0) { ErrorMsg(errorMessage); }
        }

        return input;
    }

    public static void HeaderMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"--- {msg} ---");
        Console.ResetColor();
    }

    public static void ErrorMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    public static void WarningMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    public static void SuccessMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}
