namespace ScriptureMemory
{
    public class Reference
    {
        private string _text;  // Private member variable

        public Reference(string referenceText)
        {
            _text = referenceText;
        }

        public string Text => _text;  // Read-only
    }
}
