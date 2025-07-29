using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private int Score = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        GameManager.Instance.OnPickup?.Invoke(Score);
        Destroy(gameObject);
    }
}
