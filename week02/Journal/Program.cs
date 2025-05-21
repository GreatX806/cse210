using System;
using System.Collections.Generic; // Needed for List
using System.IO; // Needed for file operations (StreamWriter, StreamReader)
using System.Linq; // Needed for Random selection from a list

// This class manages a collection of journal entries.
public class Journal
{
    // Member variable to hold the list of entries.
    public List<Entry> _entries;

    // List of prompts for the journal.
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing you learned today?", // Added another prompt
        "Describe a challenge you faced today and how you handled it." // Added another prompt
    };

    // Constructor for the Journal class.
    public Journal()
    {
        // Initialize the list of entries when a new Journal object is created.
        _entries = new List<Entry>();
    }

    // Method to add a new entry to the journal.
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Method to display all entries currently in the journal.
    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
        }
        else
        {
            Console.WriteLine("\n--- Journal Entries ---");
            foreach (Entry entry in _entries)
            {
                entry.DisplayEntry(); // Call the DisplayEntry method of the Entry object
            }
            Console.WriteLine("--- End of Journal Entries ---\n");
        }
    }

    // Method to save the current journal entries to a file.
    public void SaveToFile(string filename)
    {
        try
        {
            // Use StreamWriter to write to the file. 'true' means append, 'false' means overwrite.
            // We want to overwrite the file with the current state of the journal.
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // Write each entry to the file.
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.GetEntryAsSavableString());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}");
        }
    }

    // Method to load journal entries from a file.
    public void LoadFromFile(string filename)
    {
        // Clear any existing entries before loading from the file.
        _entries.Clear();

        try
        {
            // Use StreamReader to read from the file.
            using (StreamReader inputFile = new StreamReader(filename))
            {
                string line;
                // Read the file line by line until the end.
                while ((line = inputFile.ReadLine()) != null)
                {
                    // Split the line into parts based on the separator.
                    string[] parts = line.Split('|');

                    // Check if we have the expected number of parts (date, prompt, entry text).
                    if (parts.Length == 3)
                    {
                        // Create a new Entry object and populate its members.
                        Entry loadedEntry = new Entry();
                        loadedEntry._date = parts[0];
                        loadedEntry._promptText = parts[1];
                        loadedEntry._entryText = parts[2];

                        // Add the loaded entry to the journal's list.
                        _entries.Add(loadedEntry);
                    }
                    else
                    {
                        Console.WriteLine($"Skipping malformed line in file: {line}");
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found at {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }
    }

    // Method to get a random prompt from the list.
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count); // Get a random index within the bounds of the list
        return _prompts[index]; // Return the prompt at that random index
    }
}
