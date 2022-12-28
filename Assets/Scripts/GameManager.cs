using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action<int> OnLivesChanged;
    public int Lives { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
    }

    public void KillPlayer()
    {
        Lives--;
        OnLivesChanged?.Invoke(Lives);

        if (Lives <=0)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        Lives = 3;
        SceneManager.LoadScene(0);
    }
}
