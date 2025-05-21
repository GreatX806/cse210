using System; // This line includes the System namespace, which contains Console and Random

public class Program // The main class for our program
{
    public static void Main(string[] args) // The entry point of the program
    {
        // CSE 210 Programming Exercise 3: Loops (Guess My Number)
        // Core Requirements: Implement the basic guessing game with a loop and random number.

        // --- Start of Assignment Code (Core Requirements) ---

        // Step 3: Instead of having the user supply the magic number,
        // generate a random number from 1 to 100.

        // Create a new instance of the Random class.
        Random randomGenerator = new Random();
        // Generate a random integer between 1 (inclusive) and 101 (exclusive),
        // which effectively gives a number between 1 and 100.
        int magicNumber = randomGenerator.Next(1, 101);

        // Step 2: Ask the user for a guess.
        // We need to do this at least once before the loop starts,
        // and then again inside the loop if the guess is incorrect.

        // Declare a variable for the user's guess. Initialize it to a value
        // that is guaranteed not to match the magic number initially,
        // so the loop condition will be false on the first check if using a while loop.
        // A common practice is to initialize it outside the possible range of the magic number.
        int guess = -1; // Initialize with a value outside the 1-100 range

        // Step 4: Add a loop that keeps looping as long as the guess does not match the magic number.
        // A while loop is suitable here because we don't know how many guesses it will take.
        while (guess != magicNumber)
        {
            // Ask the user for their guess inside the loop.
            Console.Write("What is your guess? ");

            // Read the user's input (which is a string).
            string guessInput = Console.ReadLine();

            // Convert the input string to an integer.
            // Use int.Parse() as shown in previous exercises.
            // Note: This could still cause a Runtime Exception if the user enters non-numeric text.
            guess = int.Parse(guessInput);

            // Step 3 (continued): Using if statements, determine if the user needs to guess higher or lower,
            // or tell them if they guessed it.
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            // The loop condition (guess != magicNumber) handles the "You guessed it!" case
            // by terminating the loop when the guess equals the magic number.
        }

        // Once the loop finishes, it means the guess was correct.
        // Print the success message outside the loop.
        Console.WriteLine("You guessed it!");


        // --- End of Assignment Code (Core Requirements) ---
    }
}
