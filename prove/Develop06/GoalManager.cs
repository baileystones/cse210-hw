using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level;
    private int _pointsToNextLevel;

    public GoalManager()
    {
        _score = 0;
        _level = 1;
        _pointsToNextLevel = 100;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine($"\nYou are on level {_level}. {_pointsToNextLevel - _score} points until the next level. \n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Error. Please choose a number 1-6");
            }
        }
    }
    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create? ");

        int type = int.Parse(Console.ReadLine());
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }
    
    private void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }
    
    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
            outputFile.WriteLine($"Score:{_score}");
        }

        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        //DISCLAIMER: I used ChatGPT for help with some of the logic of this part
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);
                    var simpleGoal = new SimpleGoal(name, description, points);
                    if (isComplete) simpleGoal.RecordEvent();
                    _goals.Add(simpleGoal);
                }
                else if (type == "EternalGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    int amountCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    var checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    for (int i = 0; i < amountCompleted; i++)
                    {
                        checklistGoal.RecordEvent();
                    }
                    _goals.Add(checklistGoal);
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found");
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) -1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _goals[goalIndex].RecordEvent();
            _score += _goals[goalIndex].Points;
            Console.WriteLine($"Congratulations! You have earned {_goals[goalIndex].Points} points!");

            if (_score >= _pointsToNextLevel)
            {
                _level++;
                _pointsToNextLevel += 100;
                Console.WriteLine ($"Congrats! You've reached level {_level}!");
            }
        }
        else
        {
            Console.WriteLine("Error, please try again");
        }
    }
}