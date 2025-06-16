// SimpleGoal.cs
using System;

// SimpleGoal represents a goal that is completed once and then provides points.
// It inherits from the Goal base class.
public class SimpleGoal : Goal
{
    // Private member variable to track if the goal has been completed.
    private bool _isComplete;

    // Constructor for SimpleGoal.
    // Calls the base class constructor and initializes the _isComplete status.
    public SimpleGoal(string shortName, string description, int points, bool isComplete = false)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    // Overrides the RecordEvent method from the base class.
    // When a SimpleGoal is recorded, it is marked as complete.
    // Returns the points associated with this goal.
    public override int RecordEvent()
    {
        // Check if the goal is already complete to avoid re-recording it.
        if (_isComplete)
        {
            Console.WriteLine("This simple goal has already been completed.");
            return 0; // Return 0 points if already complete
        }
        else
        {
            _isComplete = true; // Mark the goal as complete
            return _points;     // Return the points for completing the goal
        }
    }

    // Overrides the IsComplete method from the base class.
    // Returns the current completion status of the simple goal.
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Overrides the GetDetailsString method from the base class.
    // Provides a formatted string showing the completion status ([X] for complete, [ ] for incomplete).
    public override string GetDetailsString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // Overrides the GetStringRepresentation method from the base class.
    // Provides a string format suitable for saving the SimpleGoal data to a file.
    // Format: SimpleGoal:shortName,description,points,isComplete
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}
