using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public class ReflectionActivity : MindfulnessActivity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() 
            : base("ReflectionActivity", "This activity will help you reflect on times in yourlife when you have shown strength and resilience. This will help you recognize the power you have and howyou can use it in other aspects of your life.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartMessage();
            Console.Clear();
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            PauseWithAnimation(3000);

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                string question = _questions[rand.Next(_questions.Count)];
                Console.WriteLine(question);
                ShowSpinner(5000); 
            }
            DisplayEndMessage();
        }

        private void ShowSpinner(int durationMilliseconds)
        {
            int interval = 250;
            int totalSteps = durationMilliseconds / interval;
            char[] spinner = new char[] { '|', '/', '-', '\\' };
            for (int i = 0; i < totalSteps; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(interval);
                Console.Write("\b");
            }

            Console.Write(" \r");
        }
    }
}
