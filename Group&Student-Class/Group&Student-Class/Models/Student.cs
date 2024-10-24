using System.Text.RegularExpressions;
using Group_Student_Class.Enums;

namespace Group_Student_Class.Models;

internal class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }
    private Gender _gender;
    public Gender? Gender {
        get { return _gender; }
        set
        {
            Console.Write("Enter student's gender (male or female): ");
            string input = Console.ReadLine();
            do
            {
                if (Enum.TryParse(input, true, out Gender result))
                {
                    _gender = result;
                    break;
                }
                App.ErrorMessage("Gender can only be male or female!");
                Console.Write("Enter student's gender (male or female): ");
                input = Console.ReadLine();
            }
            while (true);
        }
    }

    private byte _age;
    public byte Age {
        get { return _age; }
        set
        {
            string input;

            while (true)
            {
                Console.Write("Enter student's age: ");
                input = Console.ReadLine();

                if (byte.TryParse(input, out byte trueAge))
                {
                    _age = trueAge;
                    break;
                }

                App.ErrorMessage("Age must be a number!");
            }
        }
    }

    private string _phoneNumber;
    public string PhoneNumber {
        get { return _phoneNumber; }
        set
        {
            string input;
            while (true)
            {
                Console.Write("Enter student's phone number (format: +XXXXXXXXXXX): ");
                input = Console.ReadLine();

                if (Regex.IsMatch(input, @"^\+\d{1,3}\d{9}$"))
                {
                    _phoneNumber = input;
                    break;
                }

                App.ErrorMessage("Phone number format should be like this: +XXXXXXXXXXX");
            }
        }
    }
    private byte _limit = 24;

    public byte Limit => _limit;

    public Group Group { get; set; }

    public void Absent()
    {
        if (_limit > 0) _limit--;
        Console.WriteLine("The student did not come to class today.");
        if (_limit == 0) App.ErrorMessage("Got failed!");
    }
}
