using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Best Sherlock Holmes Moments","Nerd Central", 930);
        Video video2 = new Video("K-State 2024 Preseason Top Plays","Volleyball World", 300 );
        Video video3 = new Video("France Travel Vlog","Maren Travels", 1140);

        video1.AddComment(new Comment("John", "Great video"));
        video1.AddComment(new Comment("Ben", "They are so hilarous"));
        video1.AddComment(new Comment("Riley", "I loove The Hounds"));
       
        video2.AddComment(new Comment("Kevin", "#EMAW"));
        video2.AddComment(new Comment("Lucy", "Wow, excited for this season!"));
        video2.AddComment(new Comment("Abby", "soooo sick"));
        
        video3.AddComment(new Comment("Lou", "WOW so jealous"));
        video3.AddComment(new Comment("Mary Jo", "Ur outfit on the 3rd day was sooo cute"));
        video3.AddComment(new Comment("Elinore", "What was your travel budget?"));

        List<Video> videos = new List<Video> {video1, video2, video3};
        
        foreach (Video video in videos)
        {
            Console.WriteLine(video.DisplayAll());
        }

    }
}