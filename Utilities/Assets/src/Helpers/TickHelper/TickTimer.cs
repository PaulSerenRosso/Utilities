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

    public void Initiate()
    {
        InitiateEvent?.Invoke();
         _tickManager.TickEvent += Tick;
        _timer = Time;
    }

    void Tick()
    {
        _timer -= _tickManager.GetTickTime;
        if (_timer <= 0)
        {
            _tickManager.TickEvent -= Tick;
            TickEvent?.Invoke();
        }
    }

    public void Cancel()
    {
        _tickManager.TickEvent -= Tick;
        CancelEvent?.Invoke();
    }

    public void ResetCancelEvent()
    {
        CancelEvent = null;
    }

    public void ResetTickEvent()
    {
        TickEvent = null;
    }

    public void ResetInitiateEvent()
    {
        InitiateEvent = null;
    }

    public void ResetEvents()
    {
        ResetInitiateEvent();
        ResetCancelEvent();
        ResetTickEvent();
    }
    
    
}
}
