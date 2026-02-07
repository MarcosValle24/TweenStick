using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;

    [SerializeField] Slider healthBar;
    [SerializeField] Slider dashBar;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;


    void Awake()
    {
        if (instance == null)
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

    public void AddScore(string score)
    {
        if (scoreText != null)
        {
            scoreText.text = score;
        }
    }

    public void UpdateTimerText(float s)
    {
        if (timerText != null)
        {
            float minutes = Mathf.Floor(s / 60);
            float seconds = Mathf.Floor(s % 60);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

    }
}
