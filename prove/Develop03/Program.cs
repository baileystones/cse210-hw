//DISCLAIMER: This is all my own code, but I used ChatGT and the Teams class chat for help with some of the logic and troubleshooting, especially with the streak portion. 
//EXCEEDING REQUIREMENTS: I made a practice streak setting to motivate the user to keep up their work. 

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static DateTime? lastPracticeDate = null;
    static int practiceStreak = 0;
    static void Main(string[] args)
    {
        LoadStreakData();

        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
    
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"Your current practice streak is: {practiceStreak} days");

            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(2);

            if (scripture.IsCompletelyHidden())
            {
                UpdatePracticeStreak();
                break;
            }
        }

        SaveStreakData();
        Console.WriteLine("Good work! Practice again soon :)");
    }
    static void LoadStreakData()
    {
        if (File.Exists("streak.txt"))
        {
            string[] data = File.ReadAllLines("streak.txt");
            lastPracticeDate = DateTime.Parse(data[0]);
            practiceStreak = int.Parse(data[1]);
        }
    }
    static void SaveStreakData()
    {
        File.WriteAllLines("streak.txt", new[] {DateTime.Now.ToString(), practiceStreak.ToString() });
    }
    static void UpdatePracticeStreak()
    {
        DateTime today = DateTime.Now.Date;

        if (lastPracticeDate.HasValue)
        {
            if (today == lastPracticeDate.Value.AddDays(1))
            {
                practiceStreak++; 
            }
            else if (today > lastPracticeDate.Value.AddDays(1))
            {
                practiceStreak = 1; 
            }
        }
        else
        {
            practiceStreak = 1; 
        }

        lastPracticeDate = today;
    }
}