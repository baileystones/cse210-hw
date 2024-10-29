//DISCLAIMER: I used ChatGPT to help with the logic of some of my code and debugging, but this is my own work.
//EXCEEDING REQUIREMENTS: I added a level-up system, so ever 100 points the user levels up. 

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}