using System;
using System.IO;

namespace ScriptureMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use the "ScriptureFolder" folder in the current directory
            string folderPath = "..\\..\\..\\ScriptureFolder";

            // Get all CSV files
            var files = Directory.GetFiles(folderPath, "*.csv");

            if (files.Length == 0)
            {
                Console.WriteLine("No CSV files found!");
                return;
            }

            // Display the list of files
            Console.WriteLine("Please select a CSV file (enter the number):");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
            }
            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice < 0 || choice >= files.Length)
            {
                Console.WriteLine("Invalid choice. Program is ending.");
                return;
            }

            string selectedFile = files[choice];
            // Call the CSV loader method from ScriptureLoader
            Scripture scripture = ScriptureLoader.LoadScriptureFromCsv(selectedFile);

            if (scripture != null)
            {
                // Select difficulty level
                Console.WriteLine("Please select a difficulty level:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Normal");
                Console.WriteLine("3. Hard");
                int difficultyChoice = int.Parse(Console.ReadLine());

                Difficulty difficulty = (Difficulty)(difficultyChoice - 1);
                scripture.SetDifficulty(difficulty);

                scripture.DisplayScripture();
                string userInput;
                do
                {
                    Console.WriteLine("Press Enter to hide some words, or type 'quit' to exit the program.");
                    userInput = Console.ReadLine();
                    if (userInput != "quit")
                    {
                        scripture.HideRandomWords();
                        scripture.DisplayScripture();
                    }
                } while (userInput != "quit" && !scripture.AllWordsHidden());

                Console.WriteLine("All words are hidden. Goodbye!");
            }
        }
    }
}
