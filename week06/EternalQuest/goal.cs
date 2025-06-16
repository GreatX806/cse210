// Goal.cs
using System;

// This is the abstract base class for all types of goals.
// It defines the common attributes and behaviors that all goals will share.
public abstract class Goal
{
    // Private member variables for encapsulation.
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor to initialize the common attributes of a goal.
    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    // Public method to get the short name of the goal.
    public string GetShortName()
    {
        return _shortName;
    }

    // Public method to get the description of the goal.
    public string GetDescription()
    {
        return _description;
    }

    // Public method to get the points associated with the goal.
    public int GetPoints()
    {
        return _points;
    }

    // Abstract method that derived classes must implement.
    // This method defines what happens when a goal event is recorded.
    // It returns the points earned from this specific event, which might include bonuses.
    public abstract int RecordEvent();

    // Abstract method that derived classes must implement.
    // This method checks if the goal is considered complete.
    public abstract bool IsComplete();

    // Abstract method that derived classes must implement.
    // This method provides a formatted string for displaying the goal's details,
    // including its completion status.
    public abstract string GetDetailsString();

    // Abstract method that derived classes must implement.
    // This method provides a string representation of the goal, suitable for saving to a file.
    // It will include the goal type and all necessary data to reconstruct the goal.
    public abstract string GetStringRepresentation();
}
