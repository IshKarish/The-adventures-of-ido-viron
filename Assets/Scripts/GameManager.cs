using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;

    public Action<int> OnPickup;

    private void Awake()
    {
        Instance = this;
        OnPickup += AddScore;
    }

    private void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
    }
}
