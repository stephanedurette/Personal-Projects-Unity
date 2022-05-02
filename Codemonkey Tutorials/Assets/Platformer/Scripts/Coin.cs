using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager.onCoinCollected?.Invoke(1);
        Destroy(this.gameObject);
    }
}
