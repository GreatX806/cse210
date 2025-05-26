// Reference.cs
using System;

namespace ScriptureMemorizer
{
    class Reference
    {
        // Private member variables to store the components of a scripture reference.
        private string _book;
        private int _chapter;
        private int _verseStart;
        private int? _verseEnd; // Nullable int for handling single verses (no end verse)

        // Constructor for a single verse reference (e.g., John 3:16).
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verse;
            _verseEnd = null; // Set to null for a single verse
        }

        // Constructor for a verse range reference (e.g., Proverbs 3:5-6).
        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd; // Set to the end verse for a range
        }

        // Method to get the formatted display text of the reference.
        public string GetDisplayText()
        {
            if (_verseEnd.HasValue)
            {
                // Format for a verse range (e.g., "Proverbs 3:5-6")
                return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
            }
            else
            {
                // Format for a single verse (e.g., "John 3:16")
                return $"{_book} {_chapter}:{_verseStart}";
            }
        }
    }
}
