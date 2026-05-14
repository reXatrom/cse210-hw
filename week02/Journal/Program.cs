using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display all journal entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);
            }

            else if (choice == 2)
            {
                journal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("Enter the filename to save the journal: ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }

            else if (choice == 4)
            {
                Console.Write("Enter the filename to load the journal from: ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }

            else if (choice == 5)
            {
                Console.WriteLine("Exiting the journal application. Goodbye!");
            }

            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}