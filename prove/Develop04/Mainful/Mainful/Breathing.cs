using System;
using System.Threading;

namespace MindfulnessProgram
{
    public class Breathing : MindfulnessActivity
    {
        public Breathing() 
            : base("Breathe Activity", "This activity will help you relax by walking yourthrough breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartMessage();
            Console.Clear();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                CountdownWithPhase(4, "Breathe in...");
                CountdownWithPhase(6, "Now breathe out...");
                Console.WriteLine();
            }
            DisplayEndMessage();
        }
        private void CountdownWithPhase(int seconds, string phase)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write($"\r{phase} {i} ");
                Thread.Sleep(1000);
            }
            Console.Write($"\r{phase}   ");
            Console.WriteLine();
        }
    }
}
