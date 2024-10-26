//DISCLAIMER: I used ChatGPT, Stack Overflow, and some of my past code to help fix some of my code and troubleshoot, but it is my own work. 
//I did use the spinner code from the example video pretty exact.
//EXCEEDNG REQUIREMENTS: I added code to log the amount of times the user completed an activity.

using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{   
    static int breathingActivityCount = 0;
    static int reflectingActivityCount = 0;
    static int listingActivityCount = 0;

    static void Main(string[] args)
    {
       
       bool programRuns = true;
       
       while (programRuns)
       {
        Console.Clear();
        Console.WriteLine("Menu Options");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Show activity log");
        Console.WriteLine("5. Quit ");
        Console.WriteLine("Select a choice from the menu: ");
        
        string selection = Console.ReadLine();     
        
        if (selection == "1")
        {
            BreathingActivity breathingActivity = new BreathingActivity();
            breathingActivity.Run();
            breathingActivityCount++;
        }
        if (selection == "2")
        {
            ReflectingActivity reflectingActivity = new ReflectingActivity();
            reflectingActivity.Run();
            reflectingActivityCount++;
        }
        if (selection == "3")
        {
            ListingActivity listingActivity = new ListingActivity();
            listingActivity.Run();
            listingActivityCount++;
        }
        if (selection == "4")
        {
           ShowActivityLog();
        }
        if (selection == "5")
        {
            programRuns = false;
            Console.WriteLine("Thank you, goodbye!");
        }
        else
        {
            Console.WriteLine("Error. Please choose a number 1-5");
        } 
       }
    }

    static void ShowActivityLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log:");
        Console.WriteLine($"Breathing Activity Count: {breathingActivityCount}");
        Console.WriteLine($"Reflecting Activity Count: {reflectingActivityCount}");
        Console.WriteLine($"Listing Activity Count: {listingActivityCount}");
        Console.WriteLine("\n Press Enter to return to the menu");
        Console.ReadLine();
    }
}