using System;
using System.Threading;
using System.Diagnostics; // For Stopwatch

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration; // Protected so derived classes can access

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear(); // Clear console for a cleaner start
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5); // Pause for several seconds before starting
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3); // Pause before showing final message
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(5); // Pause before returning to menu
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        Stopwatch timer = new Stopwatch();
        timer.Start();
        int i = 0;
        while (timer.Elapsed.TotalSeconds < seconds)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250); // Pause for 250 milliseconds
            Console.Write("\b \b"); // Erase the spinner character
            i = (i + 1) % spinner.Count;
        }
        timer.Stop();
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000); // Pause for 1 second
            Console.Write("\b\b  \b\b"); // Erase the number and move cursor back
        }
    }

    // This method will be overridden by derived classes
    public virtual void RunActivity()
    {
        // Base implementation does nothing, or could call common messages
        DisplayStartingMessage();
        // Specific activity logic will go here in derived classes
        DisplayEndingMessage();
    }
}