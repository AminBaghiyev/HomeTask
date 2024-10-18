using System.Text;

namespace CustomStringMethods.Models;

internal class CustomString
{
    public string Value { get; set; }

    public CustomString(string value)
    {
        Value = value;
    }

    public string[] Split(char separator)
    {
        int splittedArrayLength = 1;
        for (int i = 0; i < Value.Length; i++)
        {
            if (Value[i] == separator) splittedArrayLength++;
        }

        string[] splittedString = new string[splittedArrayLength];
        int indexOfSplittedString = 0;
        StringBuilder str = new();
        for (int i = 0; i < Value.Length; i++)
        {
            if (Value[i] == separator) {
                splittedString[indexOfSplittedString] = str.ToString();
                indexOfSplittedString++;
                str.Clear();
                continue;
            }
            str.Append(Value[i]);
        }
        splittedString[indexOfSplittedString] = str.ToString();

        return splittedString;
    }

    public string[] Split(string separator)
    {
        int splittedArrayLength = 1;
        for (int i = 0; i < Value.Length - separator.Length; i++)
        {
            if (Value.Substring(i, separator.Length) == separator) splittedArrayLength++;
        }

        string[] splittedString = new string[splittedArrayLength];
        int indexOfSplittedString = 0;
        StringBuilder str = new();
        for (int i = 0; i < Value.Length; i++)
        {
            if (Value.Length - separator.Length >= i &&  Value.Substring(i, separator.Length) == separator)
            {
                splittedString[indexOfSplittedString] = str.ToString();
                indexOfSplittedString++;
                str.Clear();
                continue;
            }
            str.Append(Value[i]);
        }
        splittedString[indexOfSplittedString] = str.ToString();

        return splittedString;
    }

    public string Replace(char oldChar, char newChar)
    {
        StringBuilder str = new StringBuilder();

        for (int i = 0; i < Value.Length; i++)
        {
            if (Value[i] != oldChar) str.Append(Value[i]);
            else str.Append(newChar);
        }

        return str.ToString();
    }

    public string Replace(string oldString, string newString)
    {
        StringBuilder str = new StringBuilder();

        for (int i = 0; i < Value.Length; i++)
        {
            if (Value.Length - oldString.Length >= i && Value.Substring(i, oldString.Length) == oldString)
            {
                str.Append(newString);
                i += (oldString.Length - 1);
            } else str.Append(Value[i]);
        }

        return str.ToString();
    }

    // burada ozum startIndex olan yeni metod yazmaq yerine ozune yazdim
    public int LastIndexOf (string value, int startIndex = 0)
    {
        if (Value.Length - value.Length < startIndex || startIndex == 0) startIndex = Value.Length - value.Length;

        for (int i = startIndex; i >= 0; i--)
        {
            if (Value.Substring(i, value.Length) == value) return i;
        }

        return -1;
    }

    // burada ozum startIndex olan yeni metod yazmaq yerine ozune yazdim
    public int LastIndexOf(char value, int startIndex = 0)
    {
        if (Value.Length - 1 < startIndex || startIndex == 0) startIndex = Value.Length - 1;

        for (int i = startIndex; i >= 0; i--)
        {
            if (Value[i] == value) return i;
        }

        return -1;
    }
}
