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

    public void AddStudent(Student student)
    {
        Array.Resize(ref students, students.Length + 1);
        students[students.Length - 1] = student;
    }

    public Student? GetStudentByName(string studentName)
    {
        foreach (Student student in students)
            if (student.Name == studentName) return student;
        return null;
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
