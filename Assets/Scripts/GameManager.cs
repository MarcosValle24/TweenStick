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
        if(player == null)
            player = GameObject.Find("Player");
        
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerLife>().GetLife() <= 0)
        {
            EndGame();
        }
        
    }

    public void StartGame()
    {
        player.GetComponent<PlayerLife>().RestartLife();
        score = 0;
        UIHandler.instance.AddScore(score.ToString());
        player.SetActive(true);
        UIMenu.SetActive(false);
        UIGame.SetActive(true);
        gameObject.GetComponent<EnemyManager>().enabled = true;
    }

    void EndGame()
    {
        gameObject.GetComponent<EnemyManager>().ClearEnemies();
        gameObject.GetComponent<EnemyManager>().enabled = false;
        player.SetActive(false);
        UIGame.SetActive(false);
        UIMenu.SetActive(true);
        score = 0;
        
    }

    public void UpdateScore()
    {
        score++;
        UIHandler.instance.AddScore(score.ToString());
    }
}
