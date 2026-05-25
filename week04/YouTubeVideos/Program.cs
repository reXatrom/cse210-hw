using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");


        // Create first videos
        Video video1 = new Video();
        video1._title = "How to Code in C#";
        video1._author = "John Doe";
        video1._lengthInSeconds = 300;

        // Add comments to first video
        Comment comment1 = new Comment();
        comment1._authorName = "Alice";
        comment1._autthorText = "Great tutorial! Very helpful.";
        video1._comments.Add(comment1);

        Comment comment2 = new Comment();
        comment2._authorName = "Bob";
        comment2._autthorText = "I have a question about loops.";
        video1._comments.Add(comment2);

        Comment comment3 = new Comment();
        comment3._authorName = "Charlie";
        comment3._autthorText = "Can you make a video on classes?";
        video1._comments.Add(comment3);



        // Create second video
        Video video2 = new Video();
        video2._title = "Understanding Object-Oriented Programming";
        video2._author = "Jane Smith";
        video2._lengthInSeconds = 450;

        // Add comments to second video
        Comment comment4 = new Comment();
        comment4._authorName = "Dave";
        comment4._autthorText = "This video really clarified OOP concepts for me.";
        video2._comments.Add(comment4);

        Comment comment5 = new Comment();
        comment5._authorName = "Eve";
        comment5._autthorText = "Can you explain inheritance in more detail?";
        video2._comments.Add(comment5);

        Comment comment6 = new Comment();
        comment6._authorName = "Frank";
        comment6._autthorText = "Thanks for the great content!";
        video2._comments.Add(comment6);



        // Create third video
        Video video3 = new Video();
        video3._title = "C# Data Structures";
        video3._author = "Emily Johnson";
        video3._lengthInSeconds = 600;

        // Add comments to third video
        Comment comment7 = new Comment();
        comment7._authorName = "Grace";
        comment7._autthorText = "This video helped me understand lists and dictionaries.";
        video3._comments.Add(comment7);

        Comment comment8 = new Comment();
        comment8._authorName = "Heidi";
        comment8._autthorText = "Can you make a video on linked lists?";
        video3._comments.Add(comment8);

        Comment comment9 = new Comment();
        comment9._authorName = "Ivan";
        comment9._autthorText = "Great explanation of data structures!";
        video3._comments.Add(comment9);



        // Store videos in a list
        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);



        // Display video information and comment counts
        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");


            Console.WriteLine("Comment List: ");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._authorName}: {comment._autthorText}");
            }


            Console.WriteLine("------------------------------------------------------------------");
        }    
    }
}