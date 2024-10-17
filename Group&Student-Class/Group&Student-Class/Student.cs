using System.Text.RegularExpressions;

namespace Group_Student_Class.Models;

internal class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }
    private string _gender;
    public string Gender {
        get { return _gender; }
        set
        {
            string input;
            while (true)
            {
                Console.Write("Enter student's gender (male or female): ");
                input = Console.ReadLine();

                if (input.ToLower() == "male" || input.ToLower() == "female") break;

                App.ErrorMessage("Gender can only be male or female!");
            }
            _gender = input;
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

    private Group Group;

    public void Absent()
    {
        if (_limit > 0) _limit--;
        Console.WriteLine("The student did not come to class today.");
        if (_limit == 0) App.ErrorMessage("Got failed!");
    }

    public Group GetGroup()
    {
        return Group;
    }

    public void SetGroup(Group[] groups)
    {
        string input;
        while (true)
        {
            Console.Write("Enter student's group name: ");
            input = Console.ReadLine();

            if (Group.IsGroupExists(groups, input))
            {
                Group = Group.GetGroupByName(groups, input);
                Group.AddStudent(this, groups);
                break;
            }

            App.ErrorMessage("There is no such group.");
        }
    }
}
