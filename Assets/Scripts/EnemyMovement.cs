using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;

    private float life = 100;
    private Coroutine attack =  null;

// Start is called once before the first execution of Update after the MonoBehaviour is created
   
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
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

    private void LateUpdate()
    {
        if (agent.remainingDistance < agent.stoppingDistance && agent.remainingDistance > 0.1f)
        {
            if (attack == null)
            {
                attack = StartCoroutine(isAttacking());
            }

        }
    }

    public void GetHit(float value)
    {
        life -= value;
    }


    IEnumerator isAttacking()
    {
        Collider[] obj = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in obj)
        {
            if (col.gameObject.tag == "Player")
            {
                col.transform.GetComponent<PlayerLife>().ChangeLife(-.25f);
            }
        }
        yield return new WaitForSeconds(5);
        attack = null;

    }
    
    
    
}
