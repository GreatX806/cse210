using System; // For Console

public class Program // The main class for our program
{
    public static void Main(string[] args) // The entry point of the program
    {
        // CSE 210 Programming Exercise 5: Functions
        // This program demonstrates creating and calling several simple functions.

        // --- Main Function Logic ---

        // 1. Call the DisplayWelcome function to show the welcome message.
        DisplayWelcome();

        // 2. Call PromptUserName to get the user's name and store the returned value.
        string userName = PromptUserName();

        // 3. Call PromptUserNumber to get the user's favorite number and store the returned value.
        int favoriteNumber = PromptUserNumber();

        // 4. Call SquareNumber to calculate the square of the favorite number and store the result.
        int squaredNumber = SquareNumber(favoriteNumber);

        // 5. Call DisplayResult to show the final output using the user's name and the squared number.
        DisplayResult(userName, squaredNumber);

        // --- End of Main Function Logic ---
    }

    // --- Function Definitions ---

    // Function: DisplayWelcome
    // Purpose: Displays a welcome message to the console.
    // Parameters: None
    // Returns: void (nothing)
    public static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function: PromptUserName
    // Purpose: Prompts the user for their name and reads the input.
    // Parameters: None
    // Returns: string (the user's name)
    public static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name; // Return the name entered by the user
    }

    // Function: PromptUserNumber
    // Purpose: Prompts the user for their favorite number and reads the input.
    // Parameters: None
    // Returns: int (the user's favorite number)
    public static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string numberInput = Console.ReadLine();
        // Convert the input string to an integer.
        // int.Parse() is used here, which could cause an error if the input isn't a valid integer.
        int number = int.Parse(numberInput);
        return number; // Return the parsed integer
    }

    // Function: SquareNumber
    // Purpose: Calculates the square of an integer.
    // Parameters: An integer 'number' to be squared.
    // Returns: int (the squared number)
    public static int SquareNumber(int number)
    {
        int square = number * number;
        return square; // Return the calculated square
    }

    // Function: DisplayResult
    // Purpose: Displays the final result using the user's name and a number.
    // Parameters: A string 'name' and an integer 'numberToDisplay'.
    // Returns: void (nothing)
    public static void DisplayResult(string name, int numberToDisplay)
    {
        // Use string interpolation to format the output message.
        Console.WriteLine($"{name}, the square of your number is {numberToDisplay}");
    }

    // --- End of Function Definitions ---
}
