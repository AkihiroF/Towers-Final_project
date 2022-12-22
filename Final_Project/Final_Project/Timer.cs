namespace Final_Project;

public class Timer
{
    public static event Action OnTikWorld;
    private int _time;
    public Timer( int time)
    {
        _time = time;
        Sleep();
    }

    private void Sleep()
    {
        Thread.Sleep(_time*1000);
        OnTikWorld.Invoke();
        Sleep();
    }
}