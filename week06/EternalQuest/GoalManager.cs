using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _eventsRecorded;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _eventsRecorded = 0;
    }

    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {level}: {GetQuestTitle(level)}");
        Console.WriteLine();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
        Console.WriteLine("Goal created.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("That is not a valid goal number.");
            return;
        }

        Goal goal = _goals[choice - 1];
        int pointsEarned = goal.RecordEvent();

        if (pointsEarned == 0)
        {
            Console.WriteLine("That goal is already complete, so no points were added.");
            return;
        }

        _eventsRecorded++;
        int bonus = GetMomentumBonus();
        _score += pointsEarned + bonus;

        Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");

        if (bonus > 0)
        {
            Console.WriteLine($"Momentum bonus! You earned an extra {bonus} points for recording five events.");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_eventsRecorded);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        if (lines.Length == 0)
        {
            _score = 0;
            _eventsRecorded = 0;
            Console.WriteLine("Loaded an empty file.");
            return;
        }

        _score = int.Parse(lines[0]);
        _eventsRecorded = lines.Length > 1 ? int.Parse(lines[1]) : 0;

        for (int i = 2; i < lines.Length; i++)
        {
            _goals.Add(Goal.FromStringRepresentation(lines[i]));
        }

        Console.WriteLine("Goals loaded.");
    }

    private int GetMomentumBonus()
    {
        if (_eventsRecorded % 5 == 0)
        {
            return 100;
        }

        return 0;
    }

    private string GetQuestTitle(int level)
    {
        if (level >= 10)
        {
            return "Legendary Disciple";
        }
        else if (level >= 7)
        {
            return "Master Pathfinder";
        }
        else if (level >= 4)
        {
            return "Steady Pilgrim";
        }

        return "Beginning Seeker";
    }
}
