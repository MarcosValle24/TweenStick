using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;
    
    [SerializeField] Slider healthBar;
    [SerializeField] Slider dashBar;

    void Awake()
    {
        if( instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void UpdateHealthBar(float health)
    {
        if (healthBar != null)
        {
            healthBar.value = health;
        }
    }

    public void UpdateDashBar(float dash)
    {
        if (dashBar != null)
        {
            dashBar.value = dash;
        }
    }
}
