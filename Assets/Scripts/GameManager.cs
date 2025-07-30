using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;

    public Action<int> OnPickup;
    public Action<int> OnScoreChanged;

    public Action OnEnemyCollision;

    private void Awake()
    {
        Instance = this;
        
        OnPickup += AddScore;
        OnEnemyCollision += Restart;
    }

    private void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score);
    }

    private void Restart()
    {
        Debug.Log("You ded lol");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
