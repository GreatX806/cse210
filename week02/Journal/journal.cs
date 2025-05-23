// Journal.cs
using System;
using System.Collections.Generic;
using System.IO; // Required for file operations (StreamWriter, StreamReader)

namespace JournalProgram
{
    class Journal
    {
        // Private member variable to store a list of Entry objects.
        private List<Entry> _entries;
        // Private member variable to store a list of prompts.
        private List<string> _prompts;
        // Random object for selecting prompts.
        private Random _random;

        // Constructor for the Journal class.
        public Journal()
        {
            _entries = new List<Entry>();
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What is one thing I learned today?",
                "What challenge did I overcome today?",
                "What am I grateful for today?",
                "Describe a moment that made you smile.",
                "What new idea did I have today?"
            };
            _random = new Random();
        }

        // Method to add a new entry to the journal.
        public void AddEntry()
        {
            // Get a random prompt from the list.
            string randomPrompt = GetRandomPrompt();
            Console.WriteLine($"Prompt: {randomPrompt}");

            // Get the user's response.
            Console.Write("Your response: ");
            string userResponse = Console.ReadLine();

            // Get the current date.
            string currentDate = DateTime.Now.ToShortDateString(); // Example: "5/23/2025"

            // Create a new Entry object with the collected data.
            Entry newEntry = new Entry(currentDate, randomPrompt, userResponse);

            // Add the new entry to the list of entries.
            _entries.Add(newEntry);
            Console.WriteLine("Entry added successfully!");
        }

        // Method to display all entries in the journal.
        public void DisplayEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("Your journal is empty. Write an entry first!");
                return;
            }

            Console.WriteLine("\n--- Your Journal Entries ---");
            // Iterate through each entry and call its Display method.
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
            Console.WriteLine("--- End of Journal ---");
        }

        // Method to save the current journal entries to a specified file.
        public void SaveToFile(string filename)
        {
            try
            {
                // Use StreamWriter to write to the file. 'true' for append, 'false' for overwrite.
                // For this assignment, we overwrite the file to save the current state.
                using (StreamWriter writer = new StreamWriter(filename, false))
                {
                    // Define a separator that is unlikely to appear in the content.
                    // The problem statement suggests '|' or '~' or '~|~'. We'll use "~~~".
                    string separator = "~~~"; 

                    // Write each entry to a new line, separated by the chosen delimiter.
                    foreach (Entry entry in _entries)
                    {
                        writer.WriteLine($"{entry.Date}{separator}{entry.PromptText}{separator}{entry.EntryText}");
                    }
                }
                Console.WriteLine($"Journal saved to {filename} successfully!");
            }
            catch (Exception ex)
            {
                // Catch any exceptions during file saving and inform the user.
                Console.WriteLine($"Error saving journal to file: {ex.Message}");
            }
        }

        // Method to load journal entries from a specified file.
        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File '{filename}' not found. No entries loaded.");
                return;
            }

            try
            {
                // Clear existing entries before loading new ones.
                _entries.Clear();

                // Use StreamReader to read from the file.
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    string separator = "~~~"; // Must match the separator used in SaveToFile

                    // Read lines until the end of the file.
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into its components.
                        string[] parts = line.Split(new string[] { separator }, StringSplitOptions.None);

                        // Ensure there are enough parts to form an entry (date, prompt, entry text).
                        if (parts.Length == 3)
                        {
                            string date = parts[0];
                            string prompt = parts[1];
                            string entryText = parts[2];
                            // Create a new Entry object and add it to the list.
                            _entries.Add(new Entry(date, prompt, entryText));
                        }
                        else
                        {
                            Console.WriteLine($"Skipping malformed line in file: {line}");
                        }
                    }
                }
                Console.WriteLine($"Journal loaded from {filename} successfully! ({_entries.Count} entries)");
            }
            catch (Exception ex)
            {
                // Catch any exceptions during file loading and inform the user.
                Console.WriteLine($"Error loading journal from file: {ex.Message}");
            }
        }

        // Private helper method to get a random prompt.
        private string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}
