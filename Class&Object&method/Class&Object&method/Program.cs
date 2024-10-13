using System.Reflection;

namespace ClassObjectMethod
{
    class Program
    {
        public static void Main(string[] args)
        {
            string animalInput = "";
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Enter animal type: ");
                animalInput = Console.ReadLine().ToLower();

                isValid = animalInput switch
                {
                    "bird" => true,
                    "dog" => true,
                    "bear" => true,
                    _ => false
                };

                if (!isValid) Console.WriteLine("Please enter Bird, Dog or Bear.");
            }

            if (animalInput == "bird")
            {
                Bird animal = new();

                Console.Write("Enter bird's name: ");
                animal.Name = Console.ReadLine();

                int age;
                Console.Write("Enter bird's age: ");
                int.TryParse(Console.ReadLine(), out age);
                animal.Age = age;

                bool canSwim;
                Console.Write("Can this bird swim? (true or false): ");
                bool.TryParse(Console.ReadLine(), out canSwim);
                animal.CanSwim = canSwim;

                Type classType = animal.GetType();

                // The way we know
                foreach (var field in classType.GetFields())
                {
                    Console.WriteLine($"{field.MemberType} : {field.Name} = {field.GetValue(animal)}");
                }

                foreach (var method in classType.GetMethods())
                {
                    Console.WriteLine($"{method.MemberType} : {method.Name}");
                }
            }
            else if (animalInput == "dog")
            {
                Dog animal = new();

                Console.Write("Enter dog's name: ");
                animal.Name = Console.ReadLine();

                int age;
                Console.Write("Enter dog's age: ");
                int.TryParse(Console.ReadLine(), out age);
                animal.Age = age;

                bool hasTail;
                Console.Write("Does this dog have a tail? (true or false): ");
                bool.TryParse(Console.ReadLine(), out hasTail);
                animal.HasTail = hasTail;

                Type classType = animal.GetType();

                // with Reflection (i don't know what it is ;( )
                foreach (var member in classType.GetMembers())
                {
                    Console.Write($"{member.MemberType} : {member.Name}");

                    if (member.MemberType == System.Reflection.MemberTypes.Field)
                        Console.Write($" = {((System.Reflection.FieldInfo)member).GetValue(animal)}");

                    Console.Write("\n");
                }
            }
            else if (animalInput == "bear")
            {
                Bear animal = new();

                Console.Write("Enter bear's name: ");
                animal.Name = Console.ReadLine();

                int age;
                Console.Write("Enter bear's age: ");
                int.TryParse(Console.ReadLine(), out age);
                animal.Age = age;

                bool isWild;
                Console.Write("Is this bear wild? (true or false): ");
                bool.TryParse(Console.ReadLine(), out isWild);
                animal.IsWild = isWild;

                Type classType = animal.GetType();
                MemberInfo[] ClassInfo = classType.GetMembers();

                // with Reflection++
                foreach (var member in ClassInfo)
                {
                    Console.Write($"{member.MemberType} : {member.Name}");

                    if (member.MemberType == System.Reflection.MemberTypes.Field)
                        Console.Write($" = {((System.Reflection.FieldInfo)member).GetValue(animal)}");

                    Console.Write("\n");
                }
            }
        }
    }
}