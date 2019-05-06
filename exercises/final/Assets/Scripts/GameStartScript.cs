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
    }
}
