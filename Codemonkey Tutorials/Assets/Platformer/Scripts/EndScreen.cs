using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject winScreen, loseScreen;
    [SerializeField] private KeyCode restartKey;

    private GameStates gameState = GameStates.Playing;

    private enum GameStates
    {
        Playing,
        Died,
        Won,
    }

    // Start is called before the first frame update
    void Start()
    {
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.onPlayerDied += OpenLoseMenu;
        EventManager.onGameWon += OpenWinMenu;
    }

    private void OnDisable()
    {
        EventManager.onPlayerDied -= OpenLoseMenu;
        EventManager.onGameWon -= OpenWinMenu;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(restartKey)) return;

        switch (gameState)
        {
            case GameStates.Won:
                EventManager.onNextLevelRequested?.Invoke();
                break;
            case GameStates.Died:
                EventManager.onRestartLevelRequested?.Invoke();
                break;
            default:
                break;
        }
    }

    private void OpenLoseMenu() {
        gameState = GameStates.Died;
        loseScreen.SetActive(true);
    }

    private void OpenWinMenu()
    {
        gameState = GameStates.Won;
        winScreen.SetActive(true);
    }
}
