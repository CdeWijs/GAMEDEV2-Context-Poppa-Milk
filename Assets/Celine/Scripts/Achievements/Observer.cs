using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void OnNotify(GameEvent ev);
}

public interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(GameEvent ev);
}

public enum GameEvent
{
    Change_Into_First_Product,
    Complete_First_Level,
    Change_Into_First_Remanufactured_Product,
    Change_Into_Phone,
    Complete_Second_Level,
    Poppa_Made_Second_Joke,
    Completed_Third_Level
}