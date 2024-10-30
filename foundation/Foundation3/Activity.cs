using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime _date;
    private int _timeMinutes;

    public Activity(DateTime date, int timeMinutes)
    {
        _date = date;
        _timeMinutes = timeMinutes;
    }

    public abstract float GetDistance();
    public abstract float GetSpeed();
    public abstract float GetPace();

    protected virtual string GetActivityName()
    {
        return "Activity";
    }

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityName()} ({_timeMinutes} min): Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, {GetPace():0.0} min per km";
    }
    protected int TimeMinutes => _timeMinutes;
}