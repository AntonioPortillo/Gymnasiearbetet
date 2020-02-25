using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //Ifall man vill skapa en Signal kan man högerklicka -> create -> Signal 
//SciptableObject är för att kunna skriva kod som inte möjligtvis behöver vara kopplad till ett gameobject. Istället arbetar den i bakgrunden
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i>=0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
