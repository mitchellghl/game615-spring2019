using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int health;
    public int score;
    public int spawnRate1;
    public int spawnRate2;
    public int spawnRate3;
    private float timer;
    public GameObject player;
    public GameObject enemy;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject skull1;
    public GameObject skull2;
    public GameObject skull3;
    public GameObject gameOverText;
    public GameObject scoreTextBox;
    public GameObject highScoreText;
    public Text scoreText;
    public Text highScore;

    public bool gameOver;

    public AudioClip damage;
    public AudioSource audioPlayer;
    public AudioClip enemySpawnSound;
    public AudioSource enemySpawnPlayer;

    public bool damaged;

    void Start()
    {
        health = 3;
        score = 0;
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        scoreText = scoreTextBox.GetComponent<Text>();
        highScore = highScoreText.GetComponent<Text>();
        highScoreText.gameObject.SetActive(false);
        audioPlayer.clip = damage;
        enemySpawnPlayer.clip = enemySpawnSound;
        Debug.Log(PlayerPrefs.GetInt("High Score"));
    }

    void Update()
    {   
        //Health icons
        switch (health)
        {
            case 3:
                skull1.gameObject.SetActive(true);
                skull2.gameObject.SetActive(true);
                skull3.gameObject.SetActive(true);
                break;
            case 2:
                skull1.gameObject.SetActive(true);
                skull2.gameObject.SetActive(true);
                skull3.gameObject.SetActive(false);
                break;
            case 1:
                skull1.gameObject.SetActive(true);
                skull2.gameObject.SetActive(false);
                skull3.gameObject.SetActive(false);
                break;
            case 0:
                skull1.gameObject.SetActive(false);
                skull2.gameObject.SetActive(false);
                skull3.gameObject.SetActive(false);
                gameOver = true;
                gameOverText.gameObject.SetActive(true);
                if (score > PlayerPrefs.GetInt("High Score"))
                {
                    PlayerPrefs.SetInt("High Score", score);
                    Debug.Log(PlayerPrefs.GetInt("High Score"));
                }
                highScoreText.gameObject.SetActive(true);
                highScore.text = "High Score: " + PlayerPrefs.GetInt("High Score");
                break;
        }

        if (!gameOver)
        {
            //Increase score
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                timer = 0f;
                score++;
            }

            //Update Score
            scoreText.text = "Score: " + score;

            //Spawn enemies
            if (score % spawnRate1 == 0)
            {
                score++;
                Instantiate(enemy, spawn1.transform.position, Quaternion.identity);
                enemySpawnPlayer.Play();
            }
            if (score % spawnRate2 == 0)
            {
                score++;
                Instantiate(enemy, spawn2.transform.position, Quaternion.identity);
                enemySpawnPlayer.Play();
            }
            if (score % spawnRate3 == 0)
            {
                score++;
                Instantiate(enemy, spawn3.transform.position, Quaternion.identity);
                enemySpawnPlayer.Play();
            }
        }

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("StartScene");
            }
        }

    }

    IEnumerator DamageFlicker()
    {
        Debug.Log("I got hit");
        var sr = player.gameObject.GetComponent<SpriteRenderer>();
        while (damaged)
        {
            sr.color = new Color (1f,0.5f,0.5f,0.5f);
            yield return new WaitForSeconds(0.5f);

            sr.color = new Color(1f, 0.5f, 0.5f, 0.75f);
            yield return new WaitForSeconds(0.5f);

            sr.color = new Color(1f, 0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.5f);

            sr.color = new Color(1f, 0.5f, 0.5f, 0.75f);
            yield return new WaitForSeconds(0.5f);

            sr.color = new Color(1f, 0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.5f);

            sr.color = new Color(1f, 0.5f, 0.5f, 0.75f);
            yield return new WaitForSeconds(0.5f);

            sr.color = new Color(1f, 1f, 1f, 1f);
            damaged = false;
            yield return null;
        }
    }
}
