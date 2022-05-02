using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void PlayerDied();
    public static PlayerDied onPlayerDied;
}
