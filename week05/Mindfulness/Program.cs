using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity Feature:
        // The program tracks and displays the number of mindfulness
        // activities completed during the current session.

        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        int completedActivities = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.WriteLine($"Activities completed this session: {completedActivities}");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "3")
            {
                ListingActivity activity = new();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }
}