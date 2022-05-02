using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private int coinCount = 0;

    private void Start()
    {
        UpdateCoinUI();
    }

    private void OnEnable()
    {
        EventManager.onCoinCollected += UpdateCoinCount;
    }

    private void OnDisable()
    {
        EventManager.onCoinCollected -= UpdateCoinCount;
    }

    private void UpdateCoinCount(int addedCoins) {
        coinCount += addedCoins;
        UpdateCoinUI();
    }

    private void UpdateCoinUI() {
        coinText.text = coinCount.ToString();
    }
}
