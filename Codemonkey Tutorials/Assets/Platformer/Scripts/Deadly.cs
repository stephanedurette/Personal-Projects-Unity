using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager.onPlayerDied?.Invoke();
    }

}
