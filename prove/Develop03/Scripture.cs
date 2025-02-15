using System;
using System.Collections.Generic;
using System.Linq;  // Added to support LINQ operations

namespace ScriptureMemory
{
    public class Scripture
    {
        private Reference _reference;   // Private member variable
        private List<Word> _words;        // Private member variable
        private Difficulty _difficulty;   // Private member variable

        public Scripture(string referenceText, string text)
        {
            _reference = new Reference(referenceText);
            _words = new List<Word>();
            foreach (var word in text.Split(' '))
            {
                _words.Add(new Word(word));
            }
            _difficulty = Difficulty.Normal;
        }

        public Reference Reference => _reference;  // Read-only property to return the reference

        public void SetDifficulty(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }

        public void DisplayScripture()
        {
            Console.Clear();
            Console.WriteLine(_reference.Text);
            foreach (var word in _words)
            {
                word.DisplayWord();
            }
            Console.WriteLine();
        }

        public void HideRandomWords()
        {
            // Filter the words to select only those that are not hidden yet
            var notHiddenWords = _words.Where(word => !word.IsHidden).ToList();
            if (notHiddenWords.Count > 0)
            {
                Random rand = new Random();
                int index = rand.Next(notHiddenWords.Count);
                notHiddenWords[index].HideWord(_difficulty);
            }
        }

        public bool AllWordsHidden()
        {
            foreach (var word in _words)
            {
                if (!word.IsHidden)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
