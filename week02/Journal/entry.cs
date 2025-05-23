// Entry.cs
using System;

namespace JournalProgram
{
    class Entry
    {
        // Private member variables to store the data for a journal entry.
        private string _date;
        private string _promptText;
        private string _entryText;

        // Public properties to access the private member variables.
        // This allows other classes to read the data but not directly modify the private fields.
        public string Date
        {
            get { return _date; }
            // No 'set' accessor here if we want the data to be immutable after creation,
            // but for this assignment, a private set or no set is fine.
            // For simplicity in this context, we can just use public fields or properties with private setters.
        }

        public string PromptText
        {
            get { return _promptText; }
        }

        public string EntryText
        {
            get { return _entryText; }
        }

        // Constructor for the Entry class.
        public Entry(string date, string promptText, string entryText)
        {
            _date = date;
            _promptText = promptText;
            _entryText = entryText;
        }

        // Method to display the entry's content to the console.
        public void Display()
        {
            Console.WriteLine($"\nDate: {_date}");
            Console.WriteLine($"Prompt: {_promptText}");
            Console.WriteLine($"Entry: {_entryText}");
        }
    }
}
