using Group_Student_Class.Models;

namespace Group_Student_Class;

internal class Program
{
    static void Main(string[] args)
    {
        App.WarningMessage("Welcome to the App!");

        string input = "";
        Group[] groups = [];

        while (input != "Q")
        {
            App.WelcomeMessage();
            input = Console.ReadLine().Trim().ToUpper();
            Console.Clear();

            switch (input)
            {
                case "CG":
                    App.CreateGroupPanel(ref groups);
                    break;
                case "AS":
                    App.AddStudentPanel(groups);
                    break;
                case "FS":
                    App.StudentSearchPanel(groups);
                    break;
                case "AA":
                    App.AddAbsencePanel(groups);
                    break;
            }
        }
    }
}
