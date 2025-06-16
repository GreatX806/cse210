// Program.cs
using System;

// This is the main entry point of the Eternal Quest program.
// It orchestrates the creation and management of goals.
class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements:
        // 1. Leveling System: The program now includes a basic leveling system.
        //    Players gain levels based on their total score, with a new level every 1000 points.
        //    The current level is displayed alongside the score.
        // 2. Eternal Goal Streak Counter: Eternal Goals now track a "streak" counter,
        //    which increments each time the goal is recorded. This adds a small gamification
        //    element for ongoing goals.

        // Create an instance of the GoalManager, which handles all goal-related logic.
        GoalManager goalManager = new GoalManager();

        // Start the main application loop.
        goalManager.Start();
    }
}
