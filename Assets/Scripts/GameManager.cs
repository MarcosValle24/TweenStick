using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    int score; 
	float MaxTime = 180f;
    bool isPlaying = false;
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
        if(isPlaying) {
            MaxTime -= Time.deltaTime;
            UIHandler.instance.UpdateTimerText(MaxTime);
            if (player.GetComponent<PlayerLife>().GetLife() <= 0 || MaxTime <= 0)
            {
                EndGame();
            }
            
        }
        
    }

    public void StartGame()
    {
        isPlaying = true;
        MaxTime = 180f;
        player.GetComponent<PlayerLife>().RestartLife();
        player.GetComponent<PlayerShoot>().RestartBullets();
        score = 0;
        UIHandler.instance.AddScore(score.ToString());
        player.SetActive(true);
        UIMenu.SetActive(false);
        UIGame.SetActive(true);
        gameObject.GetComponent<EnemyManager>().enabled = true;
    }

    void EndGame()
    {
        isPlaying = false;  
        gameObject.GetComponent<EnemyManager>().ClearEnemies();
        gameObject.GetComponent<EnemyManager>().enabled = false;
        player.SetActive(false);
        UIGame.SetActive(false);
        UIMenu.SetActive(true);
        score = 0;
        
    }

    public void AddTime(int t)
    {
        this.MaxTime+=t;
    }
    
    public void UpdateScore()
    {
        score++;
        UIHandler.instance.AddScore(score.ToString());
    }
}
