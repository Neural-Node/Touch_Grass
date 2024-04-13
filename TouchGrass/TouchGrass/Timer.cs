// Timer.cs
namespace TouchGrass;

namespace TouchGrass;

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
        return countUpTimer.Elapsed;
    }
    
    
    // Add properties and methods as needed
}