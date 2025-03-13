using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public SimpleGoal(string name, string description, int points, bool isCompleted)
        : base(name, description, points)
    {
        _isCompleted = isCompleted;
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            return _points;
        }
        else
        {
            return 0;
        }
    }

    public override string GetStatus()
    {
        return $"[{(_isCompleted ? "X" : " ")}] {Name} ({Description})";
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isCompleted}";
    }
}
