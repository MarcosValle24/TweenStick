using System;
using UnityEngine;

[RequireComponent((typeof(Rigidbody)))]
public class ProjectileScript : MonoBehaviour
{
    private Rigidbody rb;
    private float timer = 1;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.AddRelativeForce(Vector3.forward * 25 );
        if (timer > 0)
        {
            timer-=Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        timer = 1;
        if(rb.linearVelocity.magnitude > 0.1f)
            rb.linearVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyMovement>().GetHit(25);
        }
        gameObject.SetActive(false);
    }
}
