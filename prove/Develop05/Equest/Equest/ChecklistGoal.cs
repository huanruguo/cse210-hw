using System;

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _timesRequired;
    private int _bonusPoints;

    public int TimesCompleted => _timesCompleted;
    public int TimesRequired => _timesRequired;

    public ChecklistGoal(string name, string description, int points, int timesRequired, int bonusPoints)
        : base(name, description, points)
    {
        _timesRequired = timesRequired;
        _bonusPoints = bonusPoints;
        _timesCompleted = 0;
    }

    public ChecklistGoal(string name, string description, int points, int timesRequired, int bonusPoints, int timesCompleted, bool isCompleted)
        : base(name, description, points)
    {
        _timesRequired = timesRequired;
        _bonusPoints = bonusPoints;
        _timesCompleted = timesCompleted;
        _isCompleted = isCompleted;
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            _timesCompleted++;

            if (_timesCompleted >= _timesRequired)
            {
                _isCompleted = true;
                return _points + _bonusPoints;
            }
            else
            {
                return _points;
            }
        }
        else
        {
            return 0;
        }
    }

    public override string GetStatus()
    {
        return $"[{(_isCompleted ? "X" : " ")}] {Name} ({Description}) -- Completed {_timesCompleted}/{_timesRequired} times";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_timesRequired}|{_bonusPoints}|{_timesCompleted}|{_isCompleted}";
    }
}
