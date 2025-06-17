// Program.cs
using System;
using System.Collections.Generic; // Important for List<T>

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running run1 = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycle1 = new Cycling("04 Nov 2022", 45, 15.0);
        Swimming swim1 = new Swimming("05 Nov 2022", 20, 40);

        activities.Add(run1);
        activities.Add(cycle1);
        activities.Add(swim1);

        Console.WriteLine("--- Exercise Summaries ---");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}