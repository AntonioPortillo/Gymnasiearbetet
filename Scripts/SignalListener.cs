using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Signallisteners används för möjliggöra att min spelare kan lyssna på en signal. Allt kan variera beroende vad för signal det är  
public class SignalListener : MonoBehaviour
{
    public Signal signal; //I den här kan man lägga in vad för signal man ska lyssna på 
    public UnityEvent signalEvent; //För att välja vad den ska göra med signalen.
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    private void OnEnable()
    {
        signal.RegisterListener(this); 
    }
    private void OnDisable()
    {
        signal.DeRegisterListener(this);
    }
}
