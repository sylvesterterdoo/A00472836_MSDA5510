using System.Diagnostics;

namespace Assignment1;

public class Timer
{
    private Stopwatch _stopwatch;

    public Timer(int elapsedTime = 0)
    {
        ElapsedTimeInMs = elapsedTime;
    }

    public long ElapsedTimeInMs { get; set; }

    public void Start()
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public void Stop()
    {
        _stopwatch.Stop();

        ElapsedTimeInMs = _stopwatch.ElapsedMilliseconds;
    }
}