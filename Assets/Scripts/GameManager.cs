using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;
    public int Lives { get; private set; }

    private int _coins;
    private int _currentLevelIndex;
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
        else
        {
            SendPlayerToCheckpoint();
        }
    }

    private void SendPlayerToCheckpoint()
    {
        var checkPointManager = FindObjectOfType<CheckpointManager>();
        var checkpoint = checkPointManager.GetLastCheckpointThatWasPassed();
        var player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = checkpoint.transform.position;
    }

    public void AddCoin()
    {
        _coins++;
        OnCoinsChanged?.Invoke(_coins);
    }

    public void MoveToNextLevel()
    {
        _currentLevelIndex++;
        SceneManager.LoadScene(_currentLevelIndex);
    }
    private void RestartGame()
    {
        Lives = 3;
        _coins = 0;
        OnCoinsChanged?.Invoke(_coins);
        SceneManager.LoadScene(0);
    }
}
