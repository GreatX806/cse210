// Word.cs
using System;
using System.Linq; // Required for string.Join()

namespace ScriptureMemorizer
{
    class Word
    {
        // Private member variables to store the word's text and its hidden state.
        private string _text;
        private bool _isHidden;

        // Constructor for the Word class.
        // Initializes a word with its text and sets it as not hidden by default.
        public Word(string text)
        {
            _text = text;
            _isHidden = false; // Words are visible by default
        }

        // Method to set the word's state to hidden.
        public void Hide()
        {
            _isHidden = true;
        }

        // Method to set the word's state to visible (optional, but good for completeness).
        public void Show()
        {
            _isHidden = false;
        }

        // Method to check if the word is currently hidden.
        public bool IsHidden()
        {
            return _isHidden;
        }

        // Method to get the display text of the word.
        // Returns underscores if hidden, otherwise returns the original word.
        public string GetDisplayText()
        {
            if (_isHidden)
            {
                // Return a string of underscores matching the length of the original word.
                // This includes any punctuation attached to the word.
                return new string('_', _text.Length);
            }
            else
            {
                // Return the original word if it's not hidden.
                return _text;
            }
        }
    }
}
