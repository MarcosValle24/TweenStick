using System;
using UnityEngine;

[RequireComponent((typeof(Rigidbody)))]
public class ProjectileScript : MonoBehaviour
{
    private Rigidbody rb;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.AddRelativeForce(Vector3.forward );
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
