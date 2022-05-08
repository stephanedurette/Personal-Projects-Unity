using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int currentLevelIndex = 0;
    [SerializeField] private List<GameObject> levels;

    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }

    private void Start()
    {
        SetCurrentLevel(currentLevelIndex);
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        EventManager.onNextLevelRequested += () => { SetCurrentLevel((currentLevelIndex + 1) % levels.Count); };
    }

    private void OnDisable()
    {
    }

    void SetCurrentLevel(int level) {
        currentLevelIndex = level;

        foreach (GameObject g in levels)
        {
            g.SetActive(false);
        }
        levels[currentLevelIndex].SetActive(true);

        EventManager.onRestartLevelRequested?.Invoke();
    }
}
