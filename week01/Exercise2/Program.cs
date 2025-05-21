using System; // This line includes the System namespace, which contains Console

public class Program // The main class for our program
{
    public static void Main(string[] args) // The entry point of the program
    {
        // CSE 210 Programming Exercise 2: If Statements
        // Core Requirements: Determine letter grade and passing status based on percentage.

        // --- Start of Assignment Code (Core Requirements) ---

        // 1. Ask the user for their grade percentage.
        Console.Write("Please enter your grade percentage: ");

        // 2. Read the user's input (which is a string).
        string gradeInput = Console.ReadLine();

        // Convert the input string to an integer.
        // Use int.Parse() as shown in the preparation material.
        // Note: This could cause a Runtime Exception if the user enters non-numeric text.
        int gradePercentage = int.Parse(gradeInput);

        // Declare a variable to hold the letter grade.
        // Initialize it to an empty string or a default value.
        string letterGrade = "";

        // 3. Use if, else if, else statements to determine the letter grade
        // and set the letterGrade variable accordingly.

        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else // If none of the above conditions are met, the grade is an F
        {
            letterGrade = "F";
        }

        // 5. Print the letter grade once after the conditional structure.
        Console.WriteLine($"Your letter grade is: {letterGrade}");

        // 4. Add a separate if statement to determine if the user passed.
        // Passing is defined as having a grade of 70 or higher.
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard for next time!");
        }


        // --- End of Assignment Code (Core Requirements) ---
    }
}
