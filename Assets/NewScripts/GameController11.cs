using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    //array of enemy objects
    // private GameObjects []hazards;
    //spawn enemy ship
    public GameObject enemyShip;

    public GameObject asteroid;
    public float spawnInterval = 2f;
    private float xValue = 6.5f;
    private float yValue = 0.0f;
    private float zValue = 4.5f;

    public float score;
    public TextMeshProUGUI scoreText;
    
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameRestartText;
    private bool isDead = false;

    void Start()
    {
        
        asteroid.GetComponent<Mover1>().speed = -2f; //set asteroid speed
        score = 0;
        gameOverText.text = "";
        gameRestartText.text = "";
        StartCoroutine(SpawnMeteors());
    }

    private void Update() 
    {
        if (isDead)
            gameRestart();
    }

    private IEnumerator SpawnMeteors()
    {
        while (true)
        {
            SpawnMeteor();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        if (score % 100 == 0)
            increaseAsteroidSpeed();
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void SpawnMeteor()
    {
        float randomX = Random.Range(-xValue, xValue);
        Vector3 spawnPosition = new Vector3(randomX, yValue, zValue);

        // Instantiate(asteroid, spawnPosition, Quaternion.identity);
        Instantiate(asteroid, spawnPosition, Quaternion.identity);
    }

    public void gameOver() 
    {
        isDead = true;
        gameOverText.text = "Game Over!";
    }

    public void gameRestart()
    {
        gameRestartText.text = "Press 'r' to restart game";
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isDead = false;
        }
        
    }

    public void increaseAsteroidSpeed() 
    {
        asteroid.GetComponent<Mover1>().speed -= 2f;
    }
}