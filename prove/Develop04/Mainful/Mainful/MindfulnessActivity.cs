using System;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class MindfulnessActivity
    {
        protected string _activityName;
        protected string _description;
        protected int _duration; 

        public MindfulnessActivity(string activityName, string description)
        {
            _activityName = activityName;
            _description = description;
        }

        public void DisplayStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_activityName} activity!");
            Console.WriteLine(_description);
            Console.Write("Please enter the duration of the activity (seconds): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out _duration) && _duration > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a valid number: ");
                }
            }
            Console.WriteLine("Getting ready to start...");
            PauseWithAnimation(3000);
        }

        public void DisplayEndMessage()
        {
            Console.WriteLine("Well Done!");
            Console.WriteLine($"Total activity duration: {_duration} seconds");
            PauseWithAnimation(3000);
        }

        public void PauseWithAnimation(int milliseconds)
        {
            int interval = 500;
            int steps = milliseconds / interval;
            for (int i = 0; i < steps; i++)
            {
                Console.Write(".");
                Thread.Sleep(interval);
            }
            Console.WriteLine();
        }
        public abstract void RunActivity();
    }
}
