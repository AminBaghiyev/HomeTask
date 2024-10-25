using ReflectionTask.Models;
using System.Reflection;

namespace ReflectionTask;

internal class Program
{
    static void Main(string[] args)
    {
        BindingFlags nonPublicFlag = BindingFlags.Instance | BindingFlags.NonPublic;
        BindingFlags nonPublicStaticFlag = BindingFlags.Static | BindingFlags.NonPublic;

        User user = new();

        #region Properties
        PropertyInfo? userId = user.GetType().GetProperty("_id", nonPublicFlag);
        userId?.SetValue(user, 0);
        Console.WriteLine($"User ID: {userId?.GetValue(user)}");

        PropertyInfo? userName = user.GetType().GetProperty("_name", nonPublicFlag);
        userName?.SetValue(user, "Amin");
        Console.WriteLine($"User's name: {userName?.GetValue(user)}");

        PropertyInfo? userSurname = user.GetType().GetProperty("_surname", nonPublicFlag);
        userSurname?.SetValue(user, "Baghiyev");
        Console.WriteLine($"User's surname: {userSurname?.GetValue(user)}");

        PropertyInfo? userAge = typeof(User).GetProperty("_age", nonPublicStaticFlag);
        userAge?.SetValue(typeof(User), 19);
        Console.WriteLine($"User's age: {userAge?.GetValue(typeof(User))}");
        #endregion

        Console.WriteLine();

        #region Methods
        MethodInfo? userGetFullName = user.GetType().GetMethod("GetFullName", nonPublicFlag);
        Console.WriteLine("GetFullName method:");
        userGetFullName?.Invoke(user, null);

        Console.WriteLine();

        MethodInfo? userChangeAge = typeof(User).GetMethod("ChangeAge", nonPublicStaticFlag);
        Console.WriteLine("ChangeAge method:");
        userChangeAge?.Invoke(typeof(User), [23]);
        Console.WriteLine($"User's new age: {userAge?.GetValue(typeof(User))}");
        #endregion
    }
}
