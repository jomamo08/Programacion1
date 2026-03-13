using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    private int score = 0;

    public TextMeshProUGUI scoreText;

    public GameObject obstaclePrefab;

    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;

    void Start()
    {
        scoreText.text = "Score: 0";

        InvokeRepeating("SpawnObstacle", 1f, 2f);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void RestScore()
    {
        score--;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        scoreText.text = "Score: " + score + " GAME OVER";
        Time.timeScale = 0f;
    }

    void SpawnObstacle()
    {
        int spawnPointIndex = Random.Range(0, 3);
        Vector3 spawnPosition;

        switch(spawnPointIndex)
        {
            case 0:
                spawnPosition = spawnPoint1.transform.position;
                break;

            case 1:
                spawnPosition = spawnPoint2.transform.position;
                break;

            case 2:
                spawnPosition = spawnPoint3.transform.position;
                break;

            default:
                spawnPosition = spawnPoint1.transform.position;
                break;
        }

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

void Update()
    {
        if(score < 0)
        {
            GameOver();
        }
    }

}