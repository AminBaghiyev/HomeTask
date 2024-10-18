namespace AccessModifiers;

public class Program
{
    static void Main(string[] args)
    {
        string attemptedInput;

        // Initializing person object
        Person person = new();

        #region person.Username section
        Region();

        ErrorMessage();
        attemptedInput = "a";
        person.Username = attemptedInput;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Username: {person.Username}");

        Enter();

        SuccessMessage();
        attemptedInput = "amin_baghiyev";
        person.Username = attemptedInput;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Username: {person.Username}");
        #endregion

        #region person.Password section
        Region();

        ErrorMessage();
        attemptedInput = "1234567nd";
        person.Password = attemptedInput;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Password: {person.Password}");

        Enter();

        SuccessMessage();
        attemptedInput = "A0b$#%cCc";
        person.Password = attemptedInput;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Password: {person.Password}");
        #endregion

        #region person.Name section
        Region();

        ErrorMessage();
        attemptedInput = "A";
        person.Name = attemptedInput;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Name: {person.Name}");

        Enter();

        SuccessMessage();
        attemptedInput = "Amin";
        person.Name = attemptedInput;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Name: {person.Name}");
        #endregion

        #region person.Surname section
        Region();

        ErrorMessage();
        attemptedInput = "B";
        person.Surname = attemptedInput;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Surname: {person.Surname}");

        Enter();

        SuccessMessage();
        attemptedInput = "Baghiyev";
        person.Surname = attemptedInput;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Surname: {person.Surname}");
        #endregion

        #region person.Age section
        Region();

        ErrorMessage();
        attemptedInput = "-5";
        byte.TryParse(attemptedInput, out byte res);
        person.Age = res;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Age: {person.Age}");

        Enter();

        SuccessMessage();
        attemptedInput = "19";
        byte.TryParse(attemptedInput, out res);
        person.Age = res;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Age: {person.Age}");
        #endregion

        #region person.Birthday section
        Region();

        ErrorMessage();
        attemptedInput = "1884-01-31";
        DateTime.TryParse(attemptedInput, out DateTime resDate);
        person.Birthday = resDate;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Birthday: {person.Birthday}");

        Enter();

        SuccessMessage();
        attemptedInput = "2004-12-05";
        DateTime.TryParse(attemptedInput, out resDate);
        person.Birthday = resDate;
        AttemptedValueMessage(attemptedInput);
        Console.WriteLine($"Birthday: {person.Birthday}");
        #endregion
    }

    static void Region()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("------------------------------");
        Console.ResetColor();
    }

    static void SuccessMessage(string message = "Correct input entered state")
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void ErrorMessage(string message = "Wrong input entered state")
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void Enter()
    {
        Console.WriteLine();
    }

    static void AttemptedValueMessage(string value)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Entered value that was attempted: ");
        Console.ResetColor();
        Console.WriteLine(value);
    }
}
