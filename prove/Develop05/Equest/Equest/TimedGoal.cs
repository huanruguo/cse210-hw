using System;
using System.Globalization;

public class TimedGoal : Goal
{
    private DateTime _deadline;

    public DateTime Deadline => _deadline;

    public TimedGoal(string name, string description, int points, string deadlineStr)
        : base(name, description, points)
    {
        _deadline = DateTime.ParseExact(deadlineStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    }

    public TimedGoal(string name, string description, int points, DateTime deadline, bool isCompleted)
        : base(name, description, points)
    {
        _deadline = deadline;
        _isCompleted = isCompleted;
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            DateTime now = DateTime.Now;
            _isCompleted = true;

            if (now <= _deadline)
            {
                return _points;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public override string GetStatus()
    {
        string deadlineStr = _deadline.ToString("dd/MM/yyyy");
        return $"{(_isCompleted ? "[X]" : "[ ]")} {Name} ({Description}) - Deadline: {deadlineStr}";
    }

    public override string GetSaveString()
    {
        string deadlineStr = _deadline.ToString("dd/MM/yyyy");
        return $"TimedGoal|{_name}|{_description}|{_points}|{deadlineStr}|{_isCompleted}";
    }
}
