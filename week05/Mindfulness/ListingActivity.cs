    using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics; // Required for Stopwatch

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void RunActivity()
    {
        // Call the base class's starting message method.
        // This will display the welcome, description, and ask for the duration.
        base.DisplayStartingMessage();

        // Initialize a random number generator to select a prompt.
        Random random = new Random();
        // Select a random prompt from the list.
        string selectedPrompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {selectedPrompt} ---");
        Console.Write("You may begin in: ");
        // Give the user a few seconds to prepare mentally.
        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing items in your mind now. When the time is up, you'll be asked how many you listed.");

        // Start a stopwatch to track the duration of the listing activity.
        Stopwatch activityTimer = new Stopwatch();
        activityTimer.Start();

        // While the activity is running, continuously show a spinner.
        // This visually indicates to the user that the activity is active.
        // The user is expected to mentally list items during this time.
        while (activityTimer.Elapsed.TotalSeconds < _duration)
        {
            // Show a spinner for a short period (e.g., 1 second)
            // This loop ensures the spinner continues to show until the main duration is met.
            ShowSpinner(1); // Use a short spinner duration to keep it animating smoothly
            // No need for a Thread.Sleep here as ShowSpinner already includes a delay.
        }
        activityTimer.Stop(); // Stop the timer when the duration is reached.

        Console.WriteLine(); // Add a newline for better formatting.
        Console.WriteLine("Time's up!");

        // After the duration, ask the user how many items they listed.
        // This is a simplification to avoid complex non-blocking console input,
        // while still meeting the requirement of displaying back the count.
        Console.Write("How many items did you list? ");
        int listedCount;
        // Try to parse the user's input for the count.
        while (!int.TryParse(Console.ReadLine(), out listedCount) || listedCount < 0)
        {
            Console.Write("Invalid input. Please enter a positive whole number: ");
        }

        Console.WriteLine($"You listed {listedCount} items!");

        // Call the base class's ending message method.
        base.DisplayEndingMessage();
    }
}
