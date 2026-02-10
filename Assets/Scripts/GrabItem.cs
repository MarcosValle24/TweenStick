using System;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            transform.GetComponentInParent<PlayerShoot>().AddBullets(15);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Health"))
        {
            transform.GetComponentInParent<PlayerLife>().ChangeLife(.2f);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Time"))
        {
            GameObject.Find("Manager").GetComponent<GameManager>().AddTime(25);
            other.gameObject.SetActive(false);
        }
    }
}
