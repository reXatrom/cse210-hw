using System;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {_prompts[random.Next(_prompts.Count)]} ---");

        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        int count = 0;

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");

        DisplayEndingMessage();
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}