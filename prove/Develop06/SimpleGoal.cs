using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

//I used ChatGPT for help with some of the logic of this part in regards to returning an X when appropriate
    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_shortName} - {_description}";
    }

    public override string GetStringRepresentation()
    {
       return $"SimpleGoal: {_shortName},{_description},{_points},{_isComplete}";
    }
}