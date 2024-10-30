public class Cycling : Activity
{
    private float _speed;
    
    public Cycling(DateTime date, int timeMinutes, float speed) : base(date,timeMinutes)
    {
        _speed = speed;
    }

    public override float GetDistance() => (_speed * TimeMinutes) / 60;
    public override float GetSpeed() => _speed;
    public override float GetPace() => 60 / _speed;
    protected override string GetActivityName() => "Cycling";
}