// Swimming.cs
public class Swimming : Activity
{
    private int _laps;
    private const double LAP_LENGTH_METERS = 50;
    private const double METERS_TO_MILES = 0.000621371;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LAP_LENGTH_METERS * METERS_TO_MILES;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0.0;
        return GetMinutes() / distance;
    }
}