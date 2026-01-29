using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform target;
    GameManager gameMananger;

    float life = 100;
    Coroutine attack =  null;
    
    

// Start is called once before the first execution of Update after the MonoBehaviour is created
   
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        gameMananger = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(target.position);
        
        if (life <= 0)
        {
            gameObject.SetActive(false);
            gameMananger.UpdateScore();
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

    private void OnDisable()
    {
        life = 100;
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
