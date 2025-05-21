using System; // This line includes the System namespace, which contains Console

public class Program // The main class for our program
{
    public static void Main(string[] args) // The entry point of the program
    {
        // The assignment asks to prompt for first and last names and display them
        // in a specific format.

        // --- Start of Assignment Code ---

        // 1. Prompt the user for their first name.
        // Use Console.Write so the cursor stays on the same line for input.
        Console.Write("What is your first name? ");

        // 2. Read the first name entered by the user.
        // Console.ReadLine() reads the entire line of input until Enter is pressed.
        // Store the input in a string variable named firstName.
        string firstName = Console.ReadLine();

        // 3. Prompt the user for their last name.
        // Again, use Console.Write for the prompt.
        Console.Write("What is your last name? ");

        // 4. Read the last name entered by the user.
        // Store the input in a string variable named lastName.
        string lastName = Console.ReadLine();

        // 5. Display the name in the required format.
        // The format is "Lastname, Firstname Lastname."
        // Use Console.WriteLine to print the output followed by a newline.
        // Use string interpolation ($"...") to easily embed the variables within the string.
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");

        // --- Additional Code: Adding the school name output ---

        // Define a string variable for the school name.
        string school = "BYU-Idaho";

        // Print the message about studying at the school using string interpolation.
        Console.WriteLine($"I am studying at {school}.");

        // --- End of Assignment Code ---

        // You may have an initial "Hello World" line from the template here.
        // Console.WriteLine("Hello World! This is the Exercise1 Project.");
        // The code above fulfills the assignment requirements.
    }
}