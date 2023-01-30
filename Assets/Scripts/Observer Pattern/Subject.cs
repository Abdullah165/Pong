using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObservers(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObservers(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifiyObservers(BallAction ballAction)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(ballAction);
        });
    }

}
