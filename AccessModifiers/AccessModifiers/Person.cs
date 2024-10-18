using CustomValidatorLibrary;

namespace AccessModifiers;

internal class Person
{
    private string _username;
    public string Username
    {
        get { return _username; }
        set
        {
            if (CustomValidator.CheckStringField(value))
                _username = value;
            else Console.WriteLine("Username must be at least 2 characters long!");
        }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
        set
        {
            if (CustomValidator.CheckPasswordField(value))
                _password = value;
            else Console.WriteLine("Password must be at least 8 characters long and contain at least one number, symbol, uppercase letter and lowercase letter!");
        }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            if (CustomValidator.CheckStringField(value))
                _name = value;
            else Console.WriteLine("Name must be at least 2 characters long!");
        }
    }

    private string _surname;
    public string Surname
    {
        get { return _surname; }
        set
        {
            if (CustomValidator.CheckStringField(value))
                _surname = value;
            else Console.WriteLine("Surname must be at least 2 characters long!");
        }
    }

    private byte _age = 1;
    public byte Age
    {
        get { return _age; }
        set
        {
            if (CustomValidator.CheckAgeField(value))
                _age = value;
            else Console.WriteLine("Age must be greater than 0!");
        }
    }

    private DateTime _birthday = new(1970, 1, 1);
    public DateTime Birthday
    {
        get { return _birthday; }
        set
        {
            if (CustomValidator.CheckBirthDayField(value))
                _birthday = value;
            else Console.WriteLine("Year must not be earlier than 1970!");
        }
    }
}