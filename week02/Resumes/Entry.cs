using System; // Needed for DateTime

// This class represents a single entry in the journal.
public class Entry
{
    // Member variables (attributes) for an entry.
    public string _date;
    public string _promptText;
    public string _entryText;

    // Constructor (optional, but good practice)
    // public Entry()
    // {
    // }

    // Method to display the entry to the console.
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine(); // Add a blank line for readability
    }

    // Method to get the entry data in a format suitable for saving to a file.
    // Using a simple separator like "|" as suggested in the simplifications.
    public string GetEntryAsSavableString()
    {
        // Replace any potential separators in the text to avoid issues when loading.
        // This is a basic approach for the simplification.
        string cleanedPrompt = _promptText.Replace("|", " ");
        string cleanedEntry = _entryText.Replace("|", " ");

        return $"{_date}|{cleanedPrompt}|{cleanedEntry}";
    }
}
