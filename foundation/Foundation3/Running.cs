public class Running : Activity
{
    private float _distance;

    public Running(DateTime date, int timeMinutes, float distance) : base(date,timeMinutes)
    {
        _distance = distance;
    }

    public override float GetDistance() => _distance;
    public override float GetSpeed() => (_distance / TimeMinutes) * 60;
    public override float GetPace() => TimeMinutes / _distance;
    protected override string GetActivityName() => "Running";
}
