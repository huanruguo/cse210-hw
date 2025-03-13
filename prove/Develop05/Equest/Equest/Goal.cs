using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isCompleted;

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public bool IsCompleted => _isCompleted;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isCompleted = false;
    }

    public abstract int RecordEvent();

    public abstract string GetStatus();

    public abstract string GetSaveString();
}
