// Program.cs
using System;
using System.Collections.Generic; // Required for List<T>

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Journal instance. This will hold all entries and prompts.
            Journal myJournal = new Journal();

            // Display a welcome message to the user.
            Console.WriteLine("Welcome to the Journal Program!");

            string choice = "";
            // Loop to display the menu and get user input until they choose to quit.
            while (choice != "5")
            {
                // Display the menu options to the user.
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                // Read the user's choice.
                choice = Console.ReadLine();

                // Process the user's choice using a switch statement.
                switch (choice)
                {
                    case "1":
                        // If the user chooses '1', add a new entry to the journal.
                        myJournal.AddEntry();
                        break;
                    case "2":
                        // If the user chooses '2', display all entries in the journal.
                        myJournal.DisplayEntries();
                        break;
                    case "3":
                        // If the user chooses '3', load entries from a file.
                        Console.Write("Enter the filename to load from: ");
                        string loadFilename = Console.ReadLine();
                        myJournal.LoadFromFile(loadFilename);
                        break;
                    case "4":
                        // If the user chooses '4', save current entries to a file.
                        Console.Write("Enter the filename to save to: ");
                        string saveFilename = Console.ReadLine();
                        myJournal.SaveToFile(saveFilename);
                        break;
                    case "5":
                        // If the user chooses '5', exit the loop and the program.
                        Console.WriteLine("Thank you for journaling! Goodbye.");
                        break;
                    default:
                        // Handle invalid choices.
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
    }
}

/*
Exceeding Requirements:
- Modular Design: The program is broken down into three distinct classes (Program, Journal, Entry), each with a specific responsibility, demonstrating good object-oriented principles and abstraction.
- Robust File Handling: Includes basic try-catch blocks for file loading and saving to gracefully handle cases where files might not exist or other file I/O errors occur.
- Random Prompt Selection: The Journal class randomly selects a prompt for each new entry, adding a helpful feature to encourage journaling.
*/
