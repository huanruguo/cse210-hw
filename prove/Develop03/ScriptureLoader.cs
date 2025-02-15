using System;
using System.IO;

namespace ScriptureMemory
{
    public static class ScriptureLoader
    {
        public static Scripture LoadScriptureFromCsv(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length < 2)
                {
                    Console.WriteLine("File format error, must contain reference and scripture content.");
                    return null;
                }

                string reference = lines[0];
                string text = lines[1];

                return new Scripture(reference, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
                return null;
            }
        }
    }
}
