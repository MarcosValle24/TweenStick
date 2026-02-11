using System;
using UnityEngine;

public enum type {Ammo, health, time}

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private type t;
    
    public type type {
        get { return t; }
        set {t = value; 
            }
        }


    private float showTime = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showTime -= Time.deltaTime;
        if (showTime <= 0)
        {
            showTime = 25;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (type == type.Ammo)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (type == type.health)
            {
            GetComponent<MeshRenderer>().material.color = Color.red;
            }
        else if (type == type.time)
            {
            GetComponent<MeshRenderer>().material.color = Color.blue;
            }
    }
}
