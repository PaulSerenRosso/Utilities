using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HelperPSR.Tick
{
public class TickManager
{
    private float _tickRate;
    private float _tickTimer;
    private static float _tickTime;
    public event System.Action TickEvent;

    public TickManager(float tickRate)
    {
        _tickRate = tickRate;
        _tickTime = 1 / tickRate;
        _tickTimer = 0;
        Tick();
    }

    public float GetTickTime
    {
        get => _tickTime;
    }

    public async void Tick()
    {
        while (true)
        { 
            if (_tickTimer >= _tickTime)
            {
                _tickTimer -= _tickTime;
                TickEvent?.Invoke();
            }
            else _tickTimer += Time.deltaTime;

            await UniTask.DelayFrame(0);
        }
    }
    
}
}