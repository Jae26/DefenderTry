using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField] private Transform player;

    public Transform[] spawnPoints;
    public GameObject[] enemy;
    int randomSpawnPoint, randomEnemy;
    public int enemyCount;
    public float startWait;
    public float waveWait;
    public float spawnWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text quitText;

    public int scoreCount = 0;
    private bool gameOver;
    private bool restart;
    private bool quit;


    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = " ";
        gameOverText.text = " ";
        quitText.text = " ";
        scoreCount = 0; //game starts with no points!

        InvokeRepeating("SpawnEnemy", 0.5f, 1.5f);
        StartCoroutine(SpawnEnemy());

        UpdateScore();


    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }

        if (quit)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }
        }

        
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                
                    randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                randomEnemy = Random.Range(0, enemy.Length);
                if (player != null)
                {
                    Instantiate(enemy[randomEnemy], 
					spawnPoints[randomSpawnPoint].position,
                        Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnWait);

            }
            //yield return new WaitForSeconds(waveWait);


            if (gameOver) //needs certain number of enemies to display?
                {
                //print("Game Over");
                    restartText.text = "Press 'R' to Restart";
                    restart = true;
                    quitText.text = "Press 'ESC' to quit";
                    quit = true;
                    break;
                }
        }
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        //print("You quit the game!");
        Application.Quit();
    }

    public void AddScore(int newScoreValue)
    {
        scoreCount += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = (" " + scoreCount);
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}
