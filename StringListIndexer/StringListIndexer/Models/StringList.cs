using System.Text;

namespace StringListIndexer.Models;

internal class StringList(params string[] values)
{
    private string[] _values = values;
    public int Length { get => _values.Length; }

    public override string ToString()
    {
        if (Length == 0) return "[]";

        StringBuilder response = new();

        foreach (string value in _values)
            response.Append($" \"{value}\",");
        response[0] = '[';
        response[^1] = ']';

        return response.ToString();
    }

    public void Add(string value)
    {
        Array.Resize(ref _values, Length + 1);
        _values[^1] = value;
    }

    public void AddRange(params string[] values)
    {
        Array.Resize(ref _values, Length + values.Length);
        for (int i = 0; i < values.Length; i++) _values[Length - values.Length + i] = values[i];
    }

    public void Remove(string value)
    {
        string[] newValues = new string[Length - 1];
        int index = 0;
        for (int i = 0; i < Length; i++)
        {
            if (_values[i] != value) newValues[index++] = _values[i];
        }
        _values = newValues;
    }

    public void RemoveAll()
    {
        _values = [];
    }

    public int this[string v]
    {
        get
        {
            for (int i = 0; i < Length; i++)
                if (_values[i] == v) return i;
            return -1;
        }
    }
}
