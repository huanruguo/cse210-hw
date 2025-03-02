using System;
using System.Threading;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Training Program!");
                Console.WriteLine("Please select an activity from menu:");
                Console.WriteLine("1. Start Breathing Exercise");
                Console.WriteLine("2. Start Reflection Exercise");
                Console.WriteLine("3. Start Listing Exercise");

                // add new function, allow user start body scan meditation
                Console.WriteLine("4. Start Body Scan Meditation");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();
                MindfulnessActivity activity = null;
                switch (choice)
                {
                    case "1":
                        activity = new Breathing();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        activity = new BodyScanMeditationActivity();
                        break;
                    case "5":
                        exit = true;
                        continue;
                    default:
                        Console.WriteLine("Invalid option, please try again!");
                        Thread.Sleep(2000);
                        continue;
                }
                if (activity != null)
                {
                    activity.RunActivity();
                }
            }
            Console.WriteLine("Thank you for using the program! Have a great day!");
        }
    }
}
