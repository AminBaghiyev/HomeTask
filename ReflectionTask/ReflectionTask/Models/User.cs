namespace ReflectionTask.Models;

internal class User
{
    private int _id { get; set; }
    private string _name { get; set; }
    private string _surname { get; set; }
    private static int _age { get; set; }

    void GetFullName()
    {
        Console.WriteLine($"{_name} {_surname}");
    }

    static void ChangeAge(int age)
    {
        _age = age;
    }
}
