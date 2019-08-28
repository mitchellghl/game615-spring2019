using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject altar;
    public GameObject villager;
    public GameObject skeleton;
    public GameObject grave;

    public int score;
    public float ritualScoreInterval;

    public float spawnTimer;
    public float spawnRate;
    public GameObject spawnPoint;

    public GameObject gameOverText;
    public GameObject gameOverPanel;
    public GameObject scoreTextBox;
    public GameObject highScoreText;
    public Text highScore;
    public Text scoreText;

    public AudioClip scoreSound;
    public AudioClip gameOverSound;
    public bool playOnce = false;
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        score = 0;

        gameOverText.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        scoreText = scoreTextBox.GetComponent<Text>();
        highScore = highScoreText.GetComponent<Text>();
        audioPlayer.clip = scoreSound;

        if (!PlayerPrefs.HasKey("High Score"))
        {
            PlayerPrefs.SetInt("High Score", 0);
        }
        Debug.Log(PlayerPrefs.GetInt("High Score"));
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;

        if (altar.GetComponent<AltarScript>().ritualTimer > ritualScoreInterval)
        {
            altar.GetComponent<AltarScript>().ritualTimer = 0;
            score++;
            audioPlayer.Play();
            Debug.Log(score);
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate)
        {
            spawnTimer = 0;
            Instantiate(villager, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StartScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (player.GetComponent<PlayerController>().gameOver == true)
        {
            audioPlayer.clip = gameOverSound;
            if(playOnce == false)
            {
                playOnce = true;
                audioPlayer.Play();
            }
            player.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
            gameOverPanel.gameObject.SetActive(true);
            if (score > PlayerPrefs.GetInt("High Score"))
            {
                PlayerPrefs.SetInt("High Score", score);
                Debug.Log(PlayerPrefs.GetInt("High Score"));
            }
            highScoreText.gameObject.SetActive(true);
            highScore.text = "High Score: " + PlayerPrefs.GetInt("High Score");
        }
    }
}
