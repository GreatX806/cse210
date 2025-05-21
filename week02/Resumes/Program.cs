using System; // For Console

// The main class where the program execution starts.
public class Program
{
    public static void Main(string[] args)
    {
        // CSE 210 W02 Project: Journal Program
        // This program allows the user to write, display, save, and load journal entries.

        // --- Main Program Logic ---

        // Create an instance of the Journal class to manage the entries.
        Journal myJournal = new Journal();

        string choice = ""; // Variable to store the user's menu choice

        // Loop to keep the program running until the user chooses to quit.
        while (choice != "5") // Assuming '5' is the quit option
        {
            // Display the menu options to the user.
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            // Read the user's choice.
            choice = Console.ReadLine();

            // Process the user's choice using if/else if/else statements.
            if (choice == "1") // Write a new entry
            {
                // Get a random prompt from the journal.
                string randomPrompt = myJournal.GetRandomPrompt();
                Console.WriteLine($"Prompt: {randomPrompt}");

                // Get the user's response.
                Console.Write("> ");
                string userResponse = Console.ReadLine();

                // Get the current date.
                // Using DateTime.Now.ToShortDateString() for simplicity as allowed by the assignment.
                string currentDate = DateTime.Now.ToShortDateString();

                // Create a new Entry object.
                Entry newEntry = new Entry();
                newEntry._date = currentDate;
                newEntry._promptText = randomPrompt;
                newEntry._entryText = userResponse;

                // Add the new entry to the journal.
                myJournal.AddEntry(newEntry);
            }
            else if (choice == "2") // Display the journal
            {
                myJournal.DisplayAllEntries(); // Call the method to display all entries
            }
            else if (choice == "3") // Load journal from file
            {
                Console.Write("Please enter the filename to load from: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename); // Call the method to load from file
            }
            else if (choice == "4") // Save journal to file
            {
                Console.Write("Please enter the filename to save to: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename); // Call the method to save to file
            }
            else if (choice == "5") // Quit the program
            {
                Console.WriteLine("Exiting Journal Program. Goodbye!");
            }
            else // Handle invalid input
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }

            Console.WriteLine(); // Add a blank line for spacing in the console
        }

        // --- End of Main Program Logic ---
    }
}
