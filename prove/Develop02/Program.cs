using System;
using System.Collections.Generic;
using System.IO;

namespace HelloCS
{
    // Represents a journal entry.
    class JournalEntry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public JournalEntry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n---------------------";
        }
    }

    // Manages journal entries.
    class Journal
    {
        public string FileName { get; set; }
        private List<JournalEntry> entries;
        private List<string> prompts;

        public Journal()
        {
            entries = new List<JournalEntry>();
            prompts = new List<string>()
            {
                "Who was the most interesting person I met today?",
                "What was the most beautiful moment of the day?",
                "How did I experience grace today?",
                "What was the strongest emotion I felt today?",
                "If I could do one thing over, what would it be?",
                "What new insight did I gain today?",
                "What challenge did I overcome today?",
                "What made me smile today?"
            };
            FileName = "";
        }

        // Create a new journal.
        public void NewJournal(string name)
        {
            if (!name.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                name = name + ".csv";
            FileName = name;
            entries.Clear();
            try
            {
                Console.WriteLine($"Journal {Path.GetFileNameWithoutExtension(FileName)} created successfully\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating journal: " + ex.Message + "\n");
            }
        }

        // Add new journal entries (1-3) without repeating prompts in one call.
        public void AddEntry()
        {
            if (string.IsNullOrEmpty(FileName))
            {
                Console.WriteLine("No journal file selected. Please create or load a journal.\n");
                return;
            }

            Random rnd = new Random();
            int numEntries = rnd.Next(1, 4); // 1 to 3 entries
            Console.WriteLine($"You will enter {numEntries} journal entries.\n");

            List<string> availablePrompts = new List<string>(prompts);

            for (int i = 0; i < numEntries; i++)
            {
                int index = rnd.Next(availablePrompts.Count);
                string prompt = availablePrompts[index];
                availablePrompts.RemoveAt(index); // Remove so it won't be used again in this call.

                Console.WriteLine($"Prompt {i + 1}: {prompt}");
                Console.Write("Enter your response: ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                JournalEntry entry = new JournalEntry(date, prompt, response);
                entries.Add(entry);
                try
                {
                    using (StreamWriter writer = new StreamWriter(FileName, true))
                    {
                        writer.WriteLine($"{date},{prompt},{response}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error writing entry to file: " + ex.Message + "\n");
                }
                Console.WriteLine("Journal entry added!\n");
            }
        }

        // Display all journal entries.
        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No journal entries available.\n");
                return;
            }
            Console.WriteLine($"Current journal file: {FileName}");
            Console.WriteLine("All journal entries:\n");
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        // Load journal from a CSV file (user provides name without extension).
        public void LoadFromFile(string fileName)
        {
            if (!fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                fileName = fileName + ".csv";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File does not exist.\n");
                return;
            }
            FileName = fileName;
            entries.Clear();
            try
            {
                string[] lines = File.ReadAllLines(FileName);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = (parts.Length > 3)
                            ? string.Join(",", parts, 2, parts.Length - 2)
                            : parts[2];
                        JournalEntry entry = new JournalEntry(date, prompt, response);
                        entries.Add(entry);
                    }
                }
                Console.WriteLine($"Journal loaded successfully. Current journal file: {FileName}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading file: " + ex.Message + "\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool exit = false;
            while (!exit)
            {
                if (string.IsNullOrEmpty(journal.FileName))
                {
                    Console.WriteLine("No journal file selected. Choose an option:");
                    Console.WriteLine("1. New Journal");
                    Console.WriteLine("2. Load Journal");
                    Console.WriteLine("3. Exit");
                    Console.Write("Your choice: ");
                    string choice = Console.ReadLine();
                    Console.WriteLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter new journal name (without extension): ");
                            string newName = Console.ReadLine();
                            journal.NewJournal(newName);
                            break;
                        case "2":
                            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");
                            if (files.Length == 0)
                            {
                                Console.WriteLine("No CSV files found.\n");
                            }
                            else
                            {
                                Console.WriteLine("Available journals:");
                                foreach (string file in files)
                                    Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                                Console.Write("Enter the journal name to load (without extension): ");
                                string loadFile = Console.ReadLine();
                                journal.LoadFromFile(loadFile);
                            }
                            break;
                        case "3":
                            exit = true;
                            Console.WriteLine("Exiting program.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Current journal file: {journal.FileName}");
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Add New Entry");
                    Console.WriteLine("2. Display Journal");
                    Console.WriteLine("3. Load Journal");
                    Console.WriteLine("4. New Journal");
                    Console.WriteLine("5. Exit");
                    Console.Write("Your choice: ");
                    string choice = Console.ReadLine();
                    Console.WriteLine();
                    switch (choice)
                    {
                        case "1":
                            journal.AddEntry();
                            break;
                        case "2":
                            journal.DisplayEntries();
                            break;
                        case "3":
                            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");
                            if (files.Length == 0)
                            {
                                Console.WriteLine("No CSV files found.\n");
                            }
                            else
                            {
                                Console.WriteLine("Available journals:");
                                foreach (string file in files)
                                    Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                                Console.Write("Enter the journal name to load (without extension): ");
                                string loadFile = Console.ReadLine();
                                journal.LoadFromFile(loadFile);
                            }
                            break;
                        case "4":
                            Console.Write("Enter new journal name (without extension): ");
                            string newDiary = Console.ReadLine();
                            journal.NewJournal(newDiary);
                            break;
                        case "5":
                            exit = true;
                            Console.WriteLine("Exiting program.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.\n");
                            break;
                    }
                }
                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}