using System;
using System.Text;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "X" : " ";
        return $"[{checkbox}] {_name} ({_description})";
    }

    protected string GetBaseData()
    {
        return $"{Encode(_name)}|{Encode(_description)}|{_points}";
    }

    protected static string Encode(string value)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    protected static string Decode(string value)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }

    public static Goal FromStringRepresentation(string data)
    {
        string[] parts = data.Split("|");
        string type = parts[0];
        string name = Decode(parts[1]);
        string description = Decode(parts[2]);
        int points = int.Parse(parts[3]);

        if (type == "SimpleGoal")
        {
            bool isComplete = bool.Parse(parts[4]);
            return new SimpleGoal(name, description, points, isComplete);
        }
        else if (type == "EternalGoal")
        {
            return new EternalGoal(name, description, points);
        }
        else if (type == "ChecklistGoal")
        {
            int target = int.Parse(parts[4]);
            int bonus = int.Parse(parts[5]);
            int amountCompleted = int.Parse(parts[6]);
            return new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
        }

        throw new FormatException($"Unknown goal type: {type}");
    }
}
