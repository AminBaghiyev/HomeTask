using System.Text.RegularExpressions;

namespace CustomValidatorLibrary;

public class CustomValidator
{
    public static bool CheckStringField(string value, int length = 2, bool trim = false)
    {
        value = trim ? value.Trim() : value;
        return value.Length >= length;
    }

    public static bool CheckPasswordField(
        string value,
        string regEx = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{8,}$",
        bool trim = false
    )
    {
        value = trim ? value.Trim() : value;
        return Regex.IsMatch(value, regEx);
    }

    public static bool CheckAgeField(byte age, byte minAge = 0) => age > minAge;
    
    public static bool CheckBirthDayField(DateTime value, DateTime? minDateTime = null)
    {
        if (minDateTime == null) minDateTime = new DateTime(1970, 1, 1);

        return value.Year >= minDateTime.Value.Year;
    }
}