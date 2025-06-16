// EternalGoal.cs
using System;

// EternalGoal represents a goal that is never completed, but provides points each time it's recorded.
// It inherits from the Goal base class.
public class EternalGoal : Goal
{
    // Exceeding Requirements: Added a streak counter for Eternal Goals.
    // This adds a gamification element where users get extra recognition for consecutive recordings.
    private int _streakCounter;

    // Constructor for EternalGoal.
    // Calls the base class constructor and initializes the streak counter.
    public EternalGoal(string shortName, string description, int points, int streakCounter = 0)
        : base(shortName, description, points)
    {
        _streakCounter = streakCounter;
    }

    // Overrides the RecordEvent method from the base class.
    // When an EternalGoal is recorded, it increments the streak counter.
    // It always returns its base points, as it's never "complete".
    public override int RecordEvent()
    {
        _streakCounter++; // Increment the streak counter with each recording.
        Console.WriteLine($"Congratulations! You've maintained your streak for {_streakCounter} times!");
        // We could add bonus points for reaching certain streak milestones here.
        // For simplicity, sticking to base points for now, but this is a point of extension.
        return _points; // Always return the base points
    }

    // Overrides the IsComplete method from the base class.
    // An EternalGoal is never truly complete, so this always returns false.
    public override bool IsComplete()
    {
        return false;
    }

    // Overrides the GetDetailsString method from the base class.
    // Provides a formatted string showing the goal description and its current streak.
    public override string GetDetailsString()
    {
        // For eternal goals, we don't use a checkbox as they are never "completed".
        // Instead, we show the streak count.
        return $"[ ] {_shortName} ({_description}) --- Currently on {_streakCounter} streak";
    }

    // Overrides the GetStringRepresentation method from the base class.
    // Provides a string format suitable for saving the EternalGoal data to a file.
    // Format: EternalGoal:shortName,description,points,streakCounter
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points},{_streakCounter}";
    }
}
