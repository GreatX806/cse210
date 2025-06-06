using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Mike", 300);
        video1.AddComment(new Comment("Alice", "This was so helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "Now I’m hungry."));
        video1.AddComment(new Comment("Charlie", "Great tips on boiling water!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("DIY Desk Setup", "TechieTom", 480);
        video2.AddComment(new Comment("Dana", "Loved the LED lights!"));
        video2.AddComment(new Comment("Eli", "Where did you get the monitor stand?"));
        video2.AddComment(new Comment("Fay", "Super clean setup."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Morning Yoga Routine", "ZenZara", 600);
        video3.AddComment(new Comment("George", "Feeling relaxed already."));
        video3.AddComment(new Comment("Hana", "Just what I needed today."));
        video3.AddComment(new Comment("Ivan", "Thanks for sharing this."));
        videos.Add(video3);

        // Display all video details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
