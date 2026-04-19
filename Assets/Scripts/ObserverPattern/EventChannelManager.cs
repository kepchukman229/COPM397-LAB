using UnityEngine;
using System.Collections.Generic;

public class EventChannelManager : PersistentSingleton<EventChannelManager>
{
    public VoidEventChannel voidEvent;
    public GameDataEventChannel gameDataEvent;
    public FloatEventChannel floatEvent;
}
