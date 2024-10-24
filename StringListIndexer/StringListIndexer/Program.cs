using StringListIndexer.Models;

namespace StringListIndexer;

internal class Program
{
    static void Main(string[] args)
    {
        StringList arr = new("Baku", "Ganja", "Quba");
        Console.WriteLine(arr);
        arr.Add("Sheki");
        Console.WriteLine(arr);
        arr.AddRange("Qusar", "Khirdalan", "Masalli");
        Console.WriteLine(arr);
        Console.WriteLine(arr.Length);
        arr.Remove("Sheki");
        Console.WriteLine(arr);
        Console.WriteLine(arr["Khirdalan"]);
        arr.RemoveAll();
        Console.WriteLine(arr);
    }
}
