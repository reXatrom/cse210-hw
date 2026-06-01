using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        // Math Assignment
        MathAssignment math = new MathAssignment(
            "Jane Doe",
            "Fractions",
            "Section 1.3",
            "1-10, 15-20");

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();



        // Writing Assignment
        WritingAssignment writing = new WritingAssignment(
            "John Smith",
            "European History",
            "The Causes of World War II");


        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}