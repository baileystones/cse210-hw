//DISCLAIMER: I used ChatGPT to help me clean up some of my code and logic, but this is my own work and design.
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var running = new Running(new DateTime(2022, 11, 3), 60, 5.0f);
        var cycling = new Cycling(new DateTime(2022, 11, 3), 30, 20.0f);
        var swimming = new Swimming(new DateTime(2022, 11, 3), 20, 20);
    
        var activities = new List<Activity> {running, cycling, swimming};

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }

}