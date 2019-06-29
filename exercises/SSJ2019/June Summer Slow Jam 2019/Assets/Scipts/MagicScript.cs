using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicScript : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private bool right;
    public int damage;

    public AudioClip shootSound;
    public AudioClip hitSound;
    public AudioSource audioPlayer;
    public AudioSource deathPlayer;
    public GameObject deathSounds;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        deathSounds = GameObject.Find("DeathSounds");
        deathPlayer = deathSounds.GetComponent<AudioSource>();

        if (player.GetComponent<PlayerController>().facingRight == true)
        {
            right = true;
        } else
        {
            right = false;
        }
        Destroy(gameObject, 1f);

        audioPlayer.clip = shootSound;
        audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetChild(0).transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 15);
        if (right)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        } else
        {
            transform.Translate(Vector2.right * -speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Villager"))
        {
            collision.gameObject.GetComponent<VillagerScript>().health -= damage;
            deathPlayer.clip = hitSound;
            deathPlayer.Play();
            Destroy(gameObject);
        }
    }
}
