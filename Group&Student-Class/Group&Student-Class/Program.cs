using Group_Student_Class.Models;

namespace Group_Student_Class;

internal class Program
{
    static void Main(string[] args)
    {
        App app = new(); // Start The App
        App.WarningMessage("Welcome to the App!");
        string input = "";

        while (input != "Q")
        {
            App.WelcomeMessage();
            input = Console.ReadLine().Trim().ToUpper();
            Console.Clear();

            switch (input)
            {
                case "CG":
                    app.CreateGroupPage();
                    break;
                case "AS":
                    app.AddStudentPage();
                    break;
                case "FS":
                    app.StudentSearchPage();
                    break;
                case "AA":
                    app.AddAbsencePage();
                    break;
            }
        }
    }
}
