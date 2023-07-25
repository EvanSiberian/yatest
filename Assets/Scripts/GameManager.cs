using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI startText;
    private bool gameState = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 0;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        score = 0;
        scoreText.text = "Score: 0";
        gameState = false;
        startText.gameObject.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
    
    public void RegisterObstacle(Obstacle obstacle)
    {
        obstacle.OnPlayerHit.AddListener(GameOver);
    }
    
    public void UnregisterObstacle(Obstacle obstacle)
    {
        obstacle.OnPlayerHit.RemoveListener(GameOver);
    }
    
    public void RegisterBonus(MovingBonus bonus)
    {
        bonus.OnPlayerTake.AddListener(AddScore);
    }
    
    public void UnregisterBonus(MovingBonus bonus)
    {
        bonus.OnPlayerTake.RemoveListener(AddScore);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        startText.gameObject.SetActive(false);
        gameState = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameState == false)
        {
            StartGame();
        }
    }
}
