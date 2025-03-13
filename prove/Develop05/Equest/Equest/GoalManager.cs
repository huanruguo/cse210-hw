using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int Score => _score;
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }
    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }

        Goal goal = _goals[goalIndex];
        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine($"You earned {pointsEarned} points! Total points: {_score}");
        }
        else
        {
            Console.WriteLine($"No points earned. Total points: {_score}");
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i}. {_goals[i].GetStatus()}");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {

            writer.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetSaveString());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        if (lines.Length > 0)
        {

            _score = int.Parse(lines[0]);


            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');
                string goalType = parts[0];

                if (goalType == "SimpleGoal")
                {

                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isCompleted = bool.Parse(parts[4]);
                    SimpleGoal sg = new SimpleGoal(name, description, points, isCompleted);
                    _goals.Add(sg);
                }
                else if (goalType == "EternalGoal")
                {

                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    EternalGoal eg = new EternalGoal(name, description, points);
                    _goals.Add(eg);
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    int timesRequired = int.Parse(parts[4]);
                    int bonusPoints = int.Parse(parts[5]);
                    int timesCompleted = int.Parse(parts[6]);
                    bool isCompleted = bool.Parse(parts[7]);
                    ChecklistGoal cg = new ChecklistGoal(name, description, points, timesRequired, bonusPoints, timesCompleted, isCompleted);
                    _goals.Add(cg);
                }
                else if (goalType == "TimedGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    string deadlineStr = parts[4];
                    bool isCompleted = bool.Parse(parts[5]);
                    DateTime deadline = DateTime.ParseExact(deadlineStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    TimedGoal tg = new TimedGoal(name, description, points, deadline, isCompleted);
                    _goals.Add(tg);
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}
