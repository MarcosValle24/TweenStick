using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public InputAction Shoot;
    [SerializeField] private GameObject bulletclone;
    [SerializeField] Transform gunpoint;
    
    List<GameObject> bullets = new List<GameObject>();

    void OnEnable()
    {
        Shoot.Enable();
    }

    private void OnDisable()
    {
        Shoot.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(bulletclone);
            temp.SetActive(false);
            bullets.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Shoot.triggered)
        {
            GameObject newBullet = GetBullet();
            if (newBullet != null)
            {
                newBullet.SetActive(true);
                newBullet.transform.position = gunpoint.position;
                newBullet.transform.rotation = gunpoint.rotation;
            }
                
        }
    }

    GameObject GetBullet()
    {
        foreach (var b in bullets)
        {
            if(!b.activeInHierarchy)
                return b;
        }
        return null;
    }
}
