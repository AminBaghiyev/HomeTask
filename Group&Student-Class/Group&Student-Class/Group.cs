namespace Group_Student_Class.Models;

internal class Group
{
    public string Name { get; set; }

    private char _shift;

    public char Shift {
        get { return _shift; }
        set
        {
            string input;
            while (true)
            {
                Console.Write("Enter group's shift (1 or 2): ");
                input = Console.ReadLine();

                if (input == "1" || input == "2") break;
                
                App.ErrorMessage("Shift must be either 1 or 2.");
            }
            _shift = Convert.ToChar(input);
        }
    }

    public Student[] students = [];

    public void AddStudent(Student student, Group[] groups)
    {
        if (!IsGroupExists(groups, Name)) {
            App.ErrorMessage("Group does not exist. Cannot add student.");
            return;
        }

        Array.Resize(ref students, students.Length + 1);
        students[students.Length - 1] = student;
    }

    public bool FindStudent(string name)
    {
        foreach (Student student in students)
            if (student.Name == name) return true;
        return false;
    }

    public static bool IsGroupExists(Group[] groups, string groupName)
    {
        foreach (Group grp in groups)
            if (grp.Name == groupName) return true;
        return false;
    }

    public static void AddGroup(ref Group[] groups, Group group)
    {
        Array.Resize(ref groups, groups.Length + 1);
        groups[groups.Length - 1] = group;
    }

    public static Group? GetGroupByName(Group[] groups, string groupName)
    {
        foreach (Group grp in groups)
            if (grp.Name == groupName) return grp;
        return null;
    }

    public Student? GetStudentByName(string studentName)
    {
        foreach (Student student in students)
            if (student.Name == studentName) return student;
        return null;
    }

    public static string[] GroupNamesToArray(Group[] groups)
    {
        string[] groupNames = new string[groups.Length];
        for (int i = 0; i < groups.Length; i++)
        {
            groupNames[i] = groups[i].Name;
        }

        return groupNames;
    }

    public string[] StudentsNamesToArray()
    {
        string[] studentsNames = new string[students.Length];
        for (int i = 0; i < students.Length; i++)
        {
            studentsNames[i] = students[i].Name;
        }

        return studentsNames;
    }
}
