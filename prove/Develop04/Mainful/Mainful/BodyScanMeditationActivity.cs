using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public class BodyScanMeditationActivity : MindfulnessActivity
    {
        // List of body parts
        private List<string> _bodyParts = new List<string>
        {
            "Head",
            "Eye",
            "Nose",
            "Mouth",
            "Neck",
            "Shoulders",
            "Arms",
            "Chest",
            "Abdomen",
            "Back",
            "Hips",
            "Thighs",
            "Calves",
            "Feet"
        };

        public BodyScanMeditationActivity()
            : base("Body Scan Meditation", "This activity will guide you to focus on different body parts sequentially, helping you relax and become more aware of your physical state.")
        {
        }

        public override void RunActivity()
        {
            // Display message
            DisplayStartMessage();
            Console.Clear();
            
            Console.WriteLine("Getting ready...");
            PauseWithAnimation(3000);

            Console.WriteLine("During this exercise, you will focus on different parts of your body one by one.");
            Console.WriteLine("Stay relaxed and try to notice subtle changes in each part.");
            PauseWithAnimation(3000);

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            int index = 0;

            while (DateTime.Now < endTime)
            {
                string currentBodyPart = _bodyParts[index % _bodyParts.Count];
                Console.WriteLine($"Please focus on: {currentBodyPart}");
                PauseWithAnimation(3000);
                index++;
            }
            DisplayEndMessage();
        }
    }
}
