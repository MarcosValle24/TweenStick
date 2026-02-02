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
        
    }

    public void StartGame()
    {
        score = 0;
        player.SetActive(true);
        UIMenu.SetActive(false);
        UIGame.SetActive(true);
        gameObject.GetComponent<EnemyManager>().enabled = true;
    }

    void EndGame()
    {
        gameObject.GetComponent<EnemyManager>().enabled = false;
        player.SetActive(false);
        score = 0;
        
    }

    public void UpdateScore()
    {
        score++;
        UIHandler.instance.AddScore(score.ToString());
    }
}
