using System;

namespace ScriptureMemory
{
    public class Word
    {
        private string _text;        // Private member variable
        private bool _isHidden;      // Private member variable
        private string _hiddenText;  // Private member variable

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
            _hiddenText = text;
        }

        public bool IsHidden => _isHidden;  // Read-only

        public void HideWord(Difficulty difficulty)
        {
            if (!_isHidden)
            {
                _isHidden = true;
                GenerateHiddenText(difficulty);
            }
        }

        public void DisplayWord()
        {
            if (_isHidden)
            {
                Console.Write(_hiddenText + " ");
            }
            else
            {
                Console.Write(_text + " ");
            }
        }

        private void GenerateHiddenText(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    _hiddenText = _text[0] + new string('_', _text.Length - 1);
                    break;
                case Difficulty.Normal:
                    _hiddenText = new string('_', _text.Length);
                    break;
                case Difficulty.Hard:
                    _hiddenText = new string('_', 3);
                    break;
            }
        }
    }
}
