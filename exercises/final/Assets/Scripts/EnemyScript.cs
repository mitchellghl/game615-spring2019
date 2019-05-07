using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public GameObject gameManager;
    private int immunityTime;
    
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        speed = Random.Range(0.5f, 5.5f);
        immunityTime = 3;
    }

    void Update()
    {
        //Movement
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 15f);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject == player && player.gameObject.GetComponent<PlayerController>().immunity == 0)
        {
            Debug.Log("Hit the player");
            player.gameObject.GetComponent<PlayerController>().immunity = immunityTime;
            gameManager.gameObject.GetComponent<GameManager>().health--;
            gameManager.gameObject.GetComponent<GameManager>().audioPlayer.Play();
            gameManager.gameObject.GetComponent<GameManager>().damaged = true;
            gameManager.gameObject.GetComponent<GameManager>().StartCoroutine("DamageFlicker");
        }
    }
}
