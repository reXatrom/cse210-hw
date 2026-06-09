using System;

// Exceeding requirements:
// This program adds a gamification system with player levels, quest titles,
// and a 100-point momentum bonus every five recorded goal events.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        while (choice != 6)
        {
            manager.DisplayPlayerInfo();
            DisplayMenu();
            choice = ReadInt("Select a choice from the menu: ");
            Console.WriteLine();

            if (choice == 1)
            {
                CreateGoal(manager);
            }
            else if (choice == 2)
            {
                manager.ListGoalDetails();
            }
            else if (choice == 3)
            {
                manager.SaveGoals(ReadText("Enter the filename to save to: "));
            }
            else if (choice == 4)
            {
                manager.LoadGoals(ReadText("Enter the filename to load from: "));
            }
            else if (choice == 5)
            {
                manager.RecordEvent();
            }
            else if (choice != 6)
            {
                Console.WriteLine("Please choose a number from 1 to 6.");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Keep going on your eternal quest!");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Quit");
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("The goal types are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int type = ReadInt("Which type of goal would you like to create? ");
        Console.WriteLine();

        string name = ReadText("What is the name of your goal? ");
        string description = ReadText("What is a short description of it? ");
        int points = ReadInt("How many points is this goal worth? ");

        if (type == 1)
        {
            manager.AddGoal(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            manager.AddGoal(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            int target = ReadInt("How many times does this goal need to be accomplished? ");
            int bonus = ReadInt("What bonus should be awarded when it is completed? ");
            manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("That goal type does not exist.");
        }
    }

    static string ReadText(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);

        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Please enter a whole number: ");
        }

        return value;
    }
}
