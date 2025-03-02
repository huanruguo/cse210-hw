using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public class ListingActivity : MindfulnessActivity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() 
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartMessage();
            // Clear the console to remove welcome and prompt messages
            Console.Clear();
            // Randomly select a prompt
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("Start listing after the countdown:");
            Countdown(5); 

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            List<string> responses = new List<string>();

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response))
                {
                    responses.Add(response);
                }
            }

            Console.WriteLine($"You listed a total of {responses.Count} items.");
            DisplayEndMessage();
        }

        private void Countdown(int seconds)
        {
            char[] spinner = new char[] { '|', '/', '-', '\\' };
            for (int i = seconds; i > 0; i--)
            {
                DateTime endTime = DateTime.Now.AddSeconds(1);
                int spinnerIndex = 0;
                while (DateTime.Now < endTime)
                {
                    Console.Write($"\r{i} {spinner[spinnerIndex % spinner.Length]}");
                    Thread.Sleep(200);
                    spinnerIndex++;
                }
            }
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }


    }
}
