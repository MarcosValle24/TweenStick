using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private float life = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLife(float change)
    {
        life += change;
        print(life);
        UIHandler.instance.UpdateHealthBar(life);
    }
}
