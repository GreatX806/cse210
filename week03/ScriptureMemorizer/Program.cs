// Program.cs
using System; // Required for Console operations

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a scripture reference for John 3:16
            Reference reference1 = new Reference("John", 3, 16);
            string text1 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
            Scripture scripture1 = new Scripture(reference1, text1);

            // Create a scripture reference for Proverbs 3:5-6 (example of a verse range)
            Reference reference2 = new Reference("Proverbs", 3, 5, 6);
            string text2 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            Scripture scripture2 = new Scripture(reference2, text2);

            // Choose one scripture to use for the demonstration
            Scripture currentScripture = scripture1; // You can change this to scripture2 to test the range

            string userInput = "";

            // Main program loop
            while (currentScripture.HasUnhiddenWords() && userInput.ToLower() != "quit")
            {
                Console.Clear(); // Clear the console screen
                Console.WriteLine(currentScripture.GetDisplayText()); // Display the current state of the scripture

                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
                Console.Write("> ");
                userInput = Console.ReadLine();

                if (userInput.ToLower() != "quit")
                {
                    // Hide a few random words (e.g., 3 words at a time)
                    // This implementation randomly selects from unhidden words (exceeds requirements)
                    currentScripture.HideRandomWords(3);
                }
            }

            Console.Clear(); // Clear one last time to show the final state
            Console.WriteLine(currentScripture.GetDisplayText()); // Display the final (fully hidden or quit) scripture
            Console.WriteLine("\nProgram ended. Thank you for using the Scripture Memorizer!");
        }
    }
}

/*
Exceeding Requirements:
- Randomly selecting from only unhidden words: The `HideRandomWords` method in the `Scripture` class ensures that only words that are currently visible are selected for hiding, providing a more effective memorization experience. This is achieved by filtering the list of words before selecting random indices.
- Handling of punctuation: The `Word` class's `GetDisplayText` method correctly replaces the *entire* word string (including any attached punctuation) with underscores, matching the length of the original word. This simplifies the hiding logic while still accurately representing the hidden word's length.
*/
