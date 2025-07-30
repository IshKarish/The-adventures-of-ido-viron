using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Agent;
    
    [SerializeField] private Transform Target;

    private void Update()
    {
        Agent.SetDestination(Target.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) GameManager.Instance.OnEnemyCollision?.Invoke();
    }
}
