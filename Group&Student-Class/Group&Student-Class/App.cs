namespace Group_Student_Class.Models;

internal class App
{
    public static void WelcomeMessage()
    {
        HeaderMessage("--- Application user manual ---");
        Console.WriteLine("Create Group -> [C] + [G]");
        Console.WriteLine("Add Student -> [A] + [S]");
        Console.WriteLine("Search for a student in the group -> [F] + [S]");
        Console.WriteLine("Add absence to the student -> [A] + [A]");
        ErrorMessage("Quit -> [Q]");
        Console.WriteLine();
    }

    public static void CreateGroupPanel(ref Group[] groups)
    {
        HeaderMessage("--- Group Creating Panel ---");

        Group group = new();

        group.Name = InfiniteInput("Enter group name: ", "Group name cannot be empty");
        group.Shift = '0'; // '0' for start to setter

        Group.AddGroup(ref groups, group);

        Console.Clear();
        SuccessMessage("Group created successfully!\n");
    }

    public static void AddStudentPanel(Group[] groups)
    {
        if (groups.Length == 0)
        {
            ErrorMessage("To add a student, you must first create a group.\n");
            return;
        }

        HeaderMessage("--- Student Adding Panel ---");

        Student student = new();

        student.Name = InfiniteInput("Enter student's name: ", "Student's name cannot be empty");
        student.Surname = InfiniteInput("Enter student's surname: ", "Student's surname cannot be empty");
        student.Gender = "0"; // "0" for start to setter
        student.Age = 0; // 0 for start to setter
        student.PhoneNumber = "0"; // "0" for start to setter
        student.SetGroup(groups);

        Console.Clear();
        SuccessMessage("Student added successfully!\n");
    }

    public static void StudentSearchPanel(Group[] groups)
    {
        if (groups.Length == 0)
        {
            ErrorMessage("To search a student, you must first create a group.\n");
            return;
        }

        HeaderMessage("--- Student Searching Panel ---");

        bool isFound = false;
        string inputStudentName = InfiniteInput("Enter a student name to search: ", "Student's name cannot be empty");

        foreach (Group grp in groups)
        {
            if (grp.FindStudent(inputStudentName))
            {
                Console.WriteLine($"{inputStudentName} was found in the {grp.Name}.");
                isFound = true;
            }
        }

        if (!isFound) ErrorMessage($"{inputStudentName} not found.");

        Console.WriteLine("\nTo go to the home page -> [H]");
        Console.WriteLine("To retry the search -> [R]");
        ErrorMessage("Quit -> [Q]\n");
        string input = InfiniteInput(["H", "R", "Q"], errorMessage: "Enter the right commands!", isUpper: true);
        Console.Clear();

        switch (input)
        {
            case "H":
                return;
            case "R":
                StudentSearchPanel(groups);
                break;
            case "Q":
                Environment.Exit(0);
                break;
        }
    }

    public static void AddAbsencePanel(Group[] groups)
    {
        if (groups.Length == 0)
        {
            ErrorMessage("To write an absence, you must first create a group.\n");
            return;
        }

        string inputGroupName = InfiniteInput(
            Group.GroupNamesToArray(groups),
            "Enter the group you want to write your absence to: ",
            "Group does not exist!"
        );

        Group group = Group.GetGroupByName(groups, inputGroupName);

        string inputStudentName = InfiniteInput(group.StudentsNamesToArray(), "Enter a student name to write absence: ", "Student not found.");

        Student student = group.GetStudentByName(inputStudentName);

        student.Absent();

        Console.WriteLine("\nTo go to the home page -> [H]");
        ErrorMessage("Quit -> [Q]\n");
        string input = InfiniteInput(["H", "Q"], errorMessage: "Enter the right commands!", isUpper: true);
        Console.Clear();

        switch (input)
        {
            case "H":
                return;
            case "Q":
                Environment.Exit(0);
                break;
        }
    }

    public static string InfiniteInput(string message = "", string errorMessage = "")
    {
        string input = "";
        while (input.Trim().Length == 0)
        {
            Console.Write(message);
            input = Console.ReadLine();
            if (input.Trim().Length == 0 && errorMessage.Trim().Length > 0) { ErrorMessage(errorMessage); }
        }

        return input;
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
            if (errorMessage.Trim().Length > 0) { ErrorMessage(errorMessage); }
        }

        return input;
    }

    public static void HeaderMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void ErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void SuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void WarningMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
