using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject winScreen, loseScreen;
    [SerializeField] private KeyCode restartKey;

    private bool isGameOver = false;

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
        if (isGameOver && Input.GetKeyDown(restartKey))
            EventManager.onRestartLevelRequested?.Invoke();
    }

    private void OpenLoseMenu() {
        isGameOver = true;
        loseScreen.SetActive(true);
    }

    private void OpenWinMenu()
    {
        isGameOver = true;
        winScreen.SetActive(true);
    }
}
