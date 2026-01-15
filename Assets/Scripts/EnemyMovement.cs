using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;

    private float life = 100;

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(target.position);
        if (life <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void GetHit(float value)
    {
        life -= value;
    }
}
