public class Swimming : Activity
{
    private int _laps;
    private const float LapDistanceInKM = 50f / 1000f;
    
    public Swimming(DateTime date, int timeMinutes, int laps) : base(date, timeMinutes)
    {
      _laps = laps;
    }

    public override float GetDistance() => _laps * LapDistanceInKM;
    public override float GetSpeed() => (GetDistance() / TimeMinutes) * 60;
    public override float GetPace() => TimeMinutes / GetDistance();
    protected override string GetActivityName() => "Swimming";
}