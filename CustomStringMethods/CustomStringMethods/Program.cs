using CustomStringMethods.Models;

namespace CustomStringMethods;

internal class Program
{
    static void Main(string[] args)
    {
        CustomString str = new("attest");

        Console.WriteLine(str.Split('t').Length);

        foreach (var st in str.Split('t'))
        {
            Console.WriteLine(st);
        }

        Console.WriteLine("--");

        string test = "attest";
        Console.WriteLine(test.Split('t').Length);
        foreach (var sr in test.Split('t'))
        {
            Console.WriteLine(sr);
        }

        Console.WriteLine("------");

        CustomString txt11 = new("hello,world,how,are,you");
        foreach (var t in txt11.Split("w"))
        {
            Console.WriteLine(t);
        }

        Console.WriteLine("-");

        string txt12 = "hello,world,how,are,you";
        foreach (var t in txt12.Split("w"))
        {
            Console.WriteLine(t);
        }

        Console.WriteLine("--");

        Console.WriteLine(str.Replace("te", "a"));
        Console.WriteLine("--");
        Console.WriteLine(test.Replace("te", "a"));

        Console.WriteLine("\n----\n");
        CustomString text11 = new("Hello world, hello, rold, world");
        Console.WriteLine(text11.LastIndexOf('r', 19));
        string text12 = "Hello world, hello, rold, world";
        Console.WriteLine(text12.LastIndexOf('r', 19));
    }
}
