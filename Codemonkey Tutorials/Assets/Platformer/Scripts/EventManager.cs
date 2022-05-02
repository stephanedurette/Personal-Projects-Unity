using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void PlayerDied();
    public static PlayerDied onPlayerDied;

    public delegate void RestartLevelRequested();
    public static RestartLevelRequested onRestartLevelRequested;

    public delegate void NextLevelRequested();
    public static NextLevelRequested onNextLevelRequested;

    public delegate void CoinCollected(int coinAmount);
    public static CoinCollected onCoinCollected;

    public delegate void GameWon();
    public static GameWon onGameWon;
}
