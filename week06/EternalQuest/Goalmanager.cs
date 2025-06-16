// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO; // Required for file operations (saving/loading)

// GoalManager class is responsible for managing all goals, the player's score,
// and handling user interaction for goal management (create, list, record, save, load).
public class GoalManager
{
    private List<Goal> _goals; // A list to store all the different goal objects.
    private int _score;        // The user's current score.
    private int _level;        // Exceeding Requirements: Added a leveling system.
    private const int PointsPerLevel = 1000; // Points needed to level up.

    // Constructor initializes the goal list, score, and level.
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1; // Start at level 1
    }

    // Public method to start the main program loop.
    public void Start()
    {
        int choice = 0;
        do
        {
            DisplayPlayerInfo(); // Always display player info at the top of the menu.
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            // Input validation for menu choice.
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        RecordEvent();
                        break;
                    case 4:
                        SaveGoals();
                        break;
                    case 5:
                        LoadGoals();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            Console.WriteLine(); // Add a blank line for better readability
        } while (choice != 6);
    }

    // Displays the player's current score and level.
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Level: {_level}");
        Console.WriteLine(); // Blank line for spacing
    }

    // Guides the user through creating a new goal.
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        if (int.TryParse(Console.ReadLine(), out int typeChoice))
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            if (int.TryParse(Console.ReadLine(), out int points))
            {
                switch (typeChoice)
                {
                    case 1: // Simple Goal
                        _goals.Add(new SimpleGoal(name, description, points));
                        Console.WriteLine("Simple Goal created!");
                        break;
                    case 2: // Eternal Goal
                        _goals.Add(new EternalGoal(name, description, points));
                        Console.WriteLine("Eternal Goal created!");
                        break;
                    case 3: // Checklist Goal
                        Console.Write("How many times does this goal need to be completed for a bonus? ");
                        if (int.TryParse(Console.ReadLine(), out int target))
                        {
                            Console.Write("What is the bonus for accomplishing it that many times? ");
                            if (int.TryParse(Console.ReadLine(), out int bonus))
                            {
                                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                                Console.WriteLine("Checklist Goal created!");
                            }
                            else { Console.WriteLine("Invalid bonus points. Goal not created."); }
                        }
                        else { Console.WriteLine("Invalid target count. Goal not created."); }
                        break;
                    default:
                        Console.WriteLine("Invalid goal type choice. Goal not created.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid points value. Goal not created.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal type choice. Goal not created.");
        }
    }

    // Lists all goals with their details.
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet. Create some goals!");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Allows the user to select a goal and record an event for it.
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record events for. Create some goals first!");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            // Only list the short names for selection.
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
        Console.Write("Which goal did you accomplish? ");

        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1]; // Get the selected goal (adjust for 0-based index)
            int pointsEarned = selectedGoal.RecordEvent(); // Polymorphic call to RecordEvent()

            _score += pointsEarned; // Add earned points to the total score.
            Console.WriteLine($"You gained {pointsEarned} points!");
            Console.WriteLine($"Your current total score is: {_score}");

            // Exceeding Requirements: Check for Level Up
            CheckForLevelUp();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    // Exceeding Requirements: Checks if the player has enough points to level up.
    private void CheckForLevelUp()
    {
        int newLevel = (_score / PointsPerLevel) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine("\n*** LEVEL UP! ***");
            Console.WriteLine($"You have reached Level {_level}!");
            Console.WriteLine("*****************\n");
        }
    }

    // Saves the current score and all goals to a text file.
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score); // Write the current score on the first line.
                outputFile.WriteLine(_level); // Exceeding Requirements: Save the level too.

                foreach (Goal goal in _goals)
                {
                    // Polymorphic call to GetStringRepresentation to get the specific goal's data.
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    // Loads goals and score from a text file.
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. No goals loaded.");
            return;
        }

        try
        {
            _goals.Clear(); // Clear current goals before loading new ones.

            string[] lines = File.ReadAllLines(filename);

            _score = int.Parse(lines[0]); // First line is the score.
            _level = int.Parse(lines[1]); // Second line is the level.

            // Start from the third line to read goal data.
            for (int i = 2; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':'); // Splits by the first colon to separate type from data.
                string goalType = parts[0];
                string goalData = parts[1];

                // Split goalData by comma to get individual attributes.
                string[] dataParts = goalData.Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        // SimpleGoal:shortName,description,points,isComplete
                        _goals.Add(new SimpleGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2]), bool.Parse(dataParts[3])));
                        break;
                    case "EternalGoal":
                        // EternalGoal:shortName,description,points,streakCounter
                        _goals.Add(new EternalGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2]), int.Parse(dataParts[3])));
                        break;
                    case "ChecklistGoal":
                        // ChecklistGoal:shortName,description,points,target,bonusPoints,amountCompleted
                        _goals.Add(new ChecklistGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2]), int.Parse(dataParts[3]), int.Parse(dataParts[4]), int.Parse(dataParts[5])));
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type '{goalType}' encountered during loading. Skipping this line.");
                        break;
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
            // Consider clearing goals or resetting score if loading failed partially.
            _goals.Clear();
            _score = 0;
            _level = 1;
        }
    }
}
