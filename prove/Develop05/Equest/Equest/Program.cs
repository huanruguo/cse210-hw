using System;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nYou have {manager.Score} points");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Please choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    Console.Write("Enter filename to save (e.g. goals.txt): ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load (e.g. goals.txt): ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    break;
                case "5":
                    RecordGoalEvent(manager);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

        Console.WriteLine("Program ended. Thank you for using!");
    }

    private static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Timed Goal");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter base points for one event: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                SimpleGoal sg = new SimpleGoal(name, description, points);
                manager.AddGoal(sg);
                Console.WriteLine("Simple Goal created.");
                break;
            case "2":
                EternalGoal eg = new EternalGoal(name, description, points);
                manager.AddGoal(eg);
                Console.WriteLine("Eternal Goal created.");
                break;
            case "3":
                Console.Write("Enter total number of completions required: ");
                int timesRequired = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points when all completions are met: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                ChecklistGoal cg = new ChecklistGoal(name, description, points, timesRequired, bonusPoints);
                manager.AddGoal(cg);
                Console.WriteLine("Checklist Goal created.");
                break;
            case "4":
                Console.Write("Enter deadline (format dd/MM/yyyy, e.g. 12/03/2025): ");
                string deadlineStr = Console.ReadLine();
                TimedGoal tg = new TimedGoal(name, description, points, deadlineStr);
                manager.AddGoal(tg);
                Console.WriteLine("Timed Goal created.");
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not created.");
                break;
        }
    }

    private static void RecordGoalEvent(GoalManager manager)
    {
        Console.WriteLine("\nCurrent Goals:");
        manager.DisplayGoals();
        Console.Write("Enter the goal index you completed: ");
        int index = int.Parse(Console.ReadLine());
        manager.RecordEvent(index);
    }
}
