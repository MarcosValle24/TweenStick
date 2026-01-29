using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score;
    private GameObject player;
    [SerializeField] GameObject UIGame;
    [SerializeField] GameObject UIMenu;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        score = 0;
        player.SetActive(true);
        UIMenu.SetActive(false);
        UIGame.SetActive(true);
    }

    void EndGame()
    {
        player.SetActive(false);
    }

    public void UpdateScore()
    {
        score++;
        UIHandler.instance.AddScore(score.ToString());
    }
}
