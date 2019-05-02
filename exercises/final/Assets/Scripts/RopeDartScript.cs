using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeDartScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<DistanceJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
        }
        if (timer > 1f)
        {
            player.GetComponent<PlayerController>().ammo = true;
            Debug.Log("Ammo refilled");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        rb.velocity = new Vector2(0,0);
        GetComponent<DistanceJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
    }
}
