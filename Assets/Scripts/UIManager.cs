using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
    }

    private void UpdateScoreText(int amount)
    {
        ScoreText.text = $"Score: {amount}";
    }
}
