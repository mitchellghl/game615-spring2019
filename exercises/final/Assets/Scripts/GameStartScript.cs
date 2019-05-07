using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour
{
    private float shake;

    void Start()
    {
        shake = 0.025f;
        if (!PlayerPrefs.HasKey("High Score"))
        {
            PlayerPrefs.SetInt("High Score", 0);
        }
        Debug.Log(PlayerPrefs.GetInt("High Score"));
    }

    void Update()
    {
        if(transform.position.y >= 13)
        {
            shake = -0.025f;
        }
        if (transform.position.y <= 11)
        {
            shake = 0.025f;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + shake, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("PlayScene");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("High Score", 0);
            Debug.Log("High Score Reset to " + PlayerPrefs.GetInt("High Score"));
        }
    }
}
