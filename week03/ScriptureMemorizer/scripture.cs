// Scripture.cs
using System;
using System.Collections.Generic; // Required for List<T>
using System.Linq; // Required for LINQ methods like .All() and .Where()

namespace ScriptureMemorizer
{
    class Scripture
    {
        // Private member variables to encapsulate the scripture's data.
        private Reference _reference; // The reference object (e.g., John 3:16)
        private List<Word> _words; // A list of Word objects representing the scripture text
        private Random _random; // Random number generator for hiding words

        // Constructor for the Scripture class.
        // Takes a Reference object and the raw text of the scripture.
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            // Split the text into words and create Word objects.
            // Using StringSplitOptions.RemoveEmptyEntries to avoid empty strings from multiple spaces.
            string[] rawWords = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string rawWord in rawWords)
            {
                _words.Add(new Word(rawWord));
            }
        }

        // Method to get the display text of the scripture.
        // This includes the reference and the text, with hidden words replaced by underscores.
        public string GetDisplayText()
        {
            // Start with the reference display text.
            string displayText = _reference.GetDisplayText() + " ";

            // Append the display text of each word.
            foreach (Word word in _words)
            {
                displayText += word.GetDisplayText() + " ";
            }

            // Trim any trailing space and return.
            return displayText.Trim();
        }

        // Method to hide a specified number of random words that are not already hidden.
        // This exceeds the core requirement by only hiding unhidden words.
        public void HideRandomWords(int count)
        {
            // Get a list of words that are currently not hidden.
            List<Word> unhiddenWords = _words.Where(word => !word.IsHidden()).ToList();

            // If there are no unhidden words left, there's nothing to hide.
            if (unhiddenWords.Count == 0)
            {
                return;
            }

            // Ensure we don't try to hide more words than are available.
            int wordsToHide = Math.Min(count, unhiddenWords.Count);

            // Hide words randomly from the unhidden list.
            for (int i = 0; i < wordsToHide; i++)
            {
                int indexToHide = _random.Next(unhiddenWords.Count);
                unhiddenWords[indexToHide].Hide(); // Call the Hide method on the Word object
                unhiddenWords.RemoveAt(indexToHide); // Remove the word from the temporary list to avoid re-selecting it
            }
        }

        // Method to check if all words in the scripture are hidden.
        public bool HasUnhiddenWords()
        {
            // Using LINQ's .Any() method to check if any word is NOT hidden.
            // If there's at least one unhidden word, the method returns true.
            // If all words are hidden, it returns false.
            return _words.Any(word => !word.IsHidden());
        }
    }
}
