using System;

namespace HelperPSR.Tick
{
public class TickTimer
{
    public event Action InitiateEvent;
    public event Action TickEvent;
    public event Action CancelEvent;
    public float Time;
    private float _timer;
    private TickManager _tickManager;

    public TickTimer(float time, TickManager tickManager)
    {
        Time = time;
        _tickManager = tickManager;
    }

    public void InitiateTimer()
    {
        InitiateEvent?.Invoke();
        // _tickManager += TickTimer;
        _timer = Time;
    }

    public void Tick()
    {
        _timer -= 1 / _tickManager.GetTickTime;
        if (_timer <= 0)
        {
            _tickManager.TickEvent -= Tick;
            TickEvent?.Invoke();
        }
    }

    public void CancelTimer()
    {
        _tickManager.TickEvent -= Tick;
        CancelEvent?.Invoke();
    }
}
}
