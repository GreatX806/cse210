// ChecklistGoal.cs
using System;

// ChecklistGoal represents a goal that must be accomplished a certain number of times
// to be complete, offering a bonus upon completion.
// It inherits from the Goal base class.
public class ChecklistGoal : Goal
{
    // Private member variables unique to ChecklistGoal.
    private int _amountCompleted; // How many times the goal has been recorded so far.
    private int _target;          // The required number of times to complete the goal.
    private int _bonusPoints;     // The extra points awarded upon final completion.

    // Constructor for ChecklistGoal.
    // Calls the base class constructor and initializes its unique attributes.
    public ChecklistGoal(string shortName, string description, int points, int target, int bonusPoints, int amountCompleted = 0)
        : base(shortName, description, points)
    {
        _target = target;
        _bonusPoints = bonusPoints;
        _amountCompleted = amountCompleted;
    }

    // Overrides the RecordEvent method from the base class.
    // Increments the completion count. If the target is reached, the bonus points are added.
    // Returns the points earned from this event (regular points + bonus if completed).
    public override int RecordEvent()
    {
        // Check if the goal is already complete.
        if (IsComplete())
        {
            Console.WriteLine("This checklist goal has already been completed.");
            return 0; // Return 0 points if already complete
        }

        _amountCompleted++; // Increment the number of times completed.
        int totalPointsEarned = _points; // Start with the regular points.

        // If the goal is now complete, add the bonus points.
        if (_amountCompleted >= _target)
        {
            totalPointsEarned += _bonusPoints;
            Console.WriteLine($"Congratulations! You have completed the goal '{_shortName}' and earned a bonus of {_bonusPoints} points!");
        }

        return totalPointsEarned; // Return the total points earned for this event.
    }

    // Overrides the IsComplete method from the base class.
    // Returns true if the amount completed meets or exceeds the target.
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Overrides the GetDetailsString method from the base class.
    // Provides a formatted string showing the completion status ([X] or [ ])
    // and the progress (e.g., "Completed 2/5 times").
    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) --- Completed {_amountCompleted}/{_target} times";
    }

    // Overrides the GetStringRepresentation method from the base class.
    // Provides a string format suitable for saving the ChecklistGoal data to a file.
    // Format: ChecklistGoal:shortName,description,points,target,bonusPoints,amountCompleted
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonusPoints},{_amountCompleted}";
    }
}
