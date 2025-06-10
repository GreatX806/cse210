using System;
using System.Threading;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void RunActivity()
    {
        base.DisplayStartingMessage();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        while (timer.Elapsed.TotalSeconds < _duration)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4); // Example: 4 seconds for breath in
            Console.WriteLine();

            if (timer.Elapsed.TotalSeconds >= _duration) break; // Check to prevent overshooting

            Console.Write("Breathe out...");
            ShowCountdown(6); // Example: 6 seconds for breath out
            Console.WriteLine();
        }
        timer.Stop();

        base.DisplayEndingMessage();
    }
}