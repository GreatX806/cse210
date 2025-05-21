using System; // For Console
using System.Collections.Generic; // For List
using System.Linq; // For potential use of Linq methods (though we'll do manual iteration for core)

public class Program // The main class for our program
{
    public static void Main(string[] args) // The entry point of the program
    {
        // CSE 210 Programming Exercise 4: Lists and Generics
        // Core Requirements: Read numbers into a list, compute sum, average, and max.

        // --- Start of Assignment Code (Core Requirements) ---

        // Create a new list to store the numbers.
        // We specify <int> inside the angle brackets because this list will hold integers.
        List<int> numbers = new List<int>();

        // Prompt the user to enter numbers.
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int inputNumber = -1; // Initialize with a value other than 0

        // Use a loop to repeatedly ask for numbers until the user enters 0.
        // A while loop is suitable here because we don't know how many numbers the user will enter.
        while (inputNumber != 0)
        {
            // Prompt the user for a number.
            Console.Write("Enter number: ");

            // Read the user's input (which is a string).
            string inputString = Console.ReadLine();

            // Convert the input string to an integer.
            // We use int.Parse() here. As noted in the preparation, this could
            // cause an error if the user enters non-numeric text.
            inputNumber = int.Parse(inputString);

            // Check if the entered number is not 0 before adding it to the list.
            if (inputNumber != 0)
            {
                numbers.Add(inputNumber); // Add the number to the list
            }
        }

        // --- Calculations based on the list ---

        // Core Requirement 1: Compute the sum of the numbers in the list.
        int sum = 0;
        // Iterate through the list using a foreach loop.
        foreach (int number in numbers)
        {
            sum += number; // Add the current number to the sum
        }
        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 2: Compute the average of the numbers in the list.
        // Check if the list is not empty to avoid division by zero.
        // Cast sum to a double to ensure floating-point division for the average.
        double average = 0; // Initialize average to 0
        if (numbers.Count > 0)
        {
            average = (double)sum / numbers.Count;
        }
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 3: Find the maximum, or largest, number in the list.
        int maxNumber = -1; // Initialize with a value lower than any expected positive number
        // We should also handle the case of an empty list.
        if (numbers.Count > 0)
        {
            maxNumber = numbers[0]; // Assume the first number is the largest initially
            // Iterate through the list to find the actual maximum.
            foreach (int number in numbers)
            {
                if (number > maxNumber)
                {
                    maxNumber = number; // Update maxNumber if a larger number is found
                }
            }
             Console.WriteLine($"The largest number is: {maxNumber}");
        }
        else
        {
             // Handle the case where the list is empty (no numbers entered before 0)
             Console.WriteLine("The list is empty, cannot find the largest number.");
        }


        // --- End of Assignment Code (Core Requirements) ---
    }
}
