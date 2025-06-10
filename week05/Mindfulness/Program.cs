using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 5) // Assuming 5 is the exit option
        {
            Console.Clear(); // Clear console before showing menu
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit"); // Changed to 4 for consistency with video
            Console.Write("Select a choice from the menu: ");

            // Input validation for menu choice
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Activity currentActivity = null;
                switch (choice)
                {
                    case 1:
                        currentActivity = new BreathingActivity();
                        break;
                    case 2:
                        currentActivity = new ReflectionActivity();
                        break;
                    case 3:
                        currentActivity = new ListingActivity();
                        break;
                    case 4: // Exit option
                        Console.WriteLine("Thank you for using the Mindfulness Program!");
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        Thread.Sleep(2000); // Pause to show error message
                        continue; // Continue to the next iteration of the loop
                }

                if (currentActivity != null)
                {
                    currentActivity.RunActivity();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Thread.Sleep(2000); // Pause to show error message
            }
        }
    }
}
