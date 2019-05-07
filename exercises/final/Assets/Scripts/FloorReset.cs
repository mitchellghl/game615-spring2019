using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorReset : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject == player && gameManager.gameObject.GetComponent<GameManager>().gameOver == false)
        {
            player.gameObject.transform.eulerAngles = new Vector2(0, 0);
        }
    }
}
