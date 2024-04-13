// Timer.cs
namespace TouchGrass;

using System.Diagnostics;

public class Timer
{
    private readonly Stopwatch _countUpTimer;

    public Timer()
    {
        _countUpTimer = new Stopwatch();
        _countUpTimer.Start();
    }

    public TimeSpan GetTime()
    {
        return _countUpTimer.Elapsed.Minutes > 1 ? new TimeSpan(0, 99, 99) : _countUpTimer.Elapsed;
    }

    public void RestartTime()
    {
        _countUpTimer.Restart();
    }

    public void ResetTime()
    {
        _countUpTimer.Reset();
    }

    public void StartTime()
    {
        _countUpTimer.Start();
    }
    
    
    // Add properties and methods as needed
}