using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemybase;
    [SerializeField] private Transform[] spawnpoints;

    List<GameObject> enemies = new List<GameObject>();

    private float maxTime = 3;
    private float time = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject clone = Instantiate(enemybase);
            clone.SetActive(false);
            enemies.Add(clone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= maxTime)
        {
            SpawnNewEnemy();
            time = 0;
        }
    }

    void SpawnNewEnemy()
    {
        int value = Random.Range(0, spawnpoints.Length);
        GameObject temp = GetEnemy();
        temp.transform.position = spawnpoints[value].position;
        temp.SetActive(true);
    }

    public void ClearEnemies()
    {
        foreach (var e in enemies)
        {
            e.SetActive(false);
        }
    }
    
    GameObject GetEnemy()
    {
        foreach (var clone in enemies)
        {
            if (!clone.activeInHierarchy)
            {
                return clone;
            }
        }
        GameObject c = Instantiate(enemybase);
        c.SetActive(false);
        enemies.Add(c);
        return c;
    }

}
