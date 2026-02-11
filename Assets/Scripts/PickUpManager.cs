using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    [SerializeField] private GameObject pickup;
    List<GameObject> pickups = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(pickup, transform.position, transform.rotation);
            pickups.Add(temp);
            temp.SetActive(false);
        }
    }
    
   public void ReturnPickup(Vector3 position, type t)
    {
        foreach (var p in pickups)
        {
            if (!p.activeInHierarchy)
            {
                p.transform.position = position;
                p.GetComponent<PickUpItem>().type = t;
                p.SetActive(true);
                break;
            }
        }
    }

    public void ClearPickups()
    {
        foreach (var p in pickups)
        {
            p.SetActive(false);
        }
    }
    
}
