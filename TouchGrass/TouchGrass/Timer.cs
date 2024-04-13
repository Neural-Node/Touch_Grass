// Timer.cs
namespace TouchGrass;

using System.Diagnostics;

public class Timer
{
    private readonly Stopwatch countUpTimer;

    public Timer()
    {
        countUpTimer = new Stopwatch();
        countUpTimer.Start();
    }

    public TimeSpan GetTime()
    {
        return countUpTimer.Elapsed.Minutes > 1 ? new TimeSpan(0, 99, 99) : countUpTimer.Elapsed;
    }

    public void RestartTime()
    {
        countUpTimer.Restart();
    }

    public void ResetTime()
    {
        countUpTimer.Reset();
    }

    public void StartTime()
    {
        countUpTimer.Start();
    }
    
    
    // Add properties and methods as needed
}