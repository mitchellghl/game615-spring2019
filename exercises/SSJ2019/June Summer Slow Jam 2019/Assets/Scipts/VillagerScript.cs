using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour
{
    public bool facingRight = true;
    public float speed;
    private Rigidbody2D rb;
    public int health;
    public int damage;
    public GameObject grave;
    private SpriteRenderer sr;

    public AudioClip spawnSound;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public AudioSource audioPlayer;
    public AudioSource deathPlayer;
    public GameObject deathSounds;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (Random.value > 0.5)
        {
            speed *= -1;
            facingRight = !facingRight;
            sr.flipX = !sr.flipX;
        }

        audioPlayer.clip = spawnSound;
        audioPlayer.Play();
        deathSounds = GameObject.Find("DeathSounds");
        deathPlayer = deathSounds.GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (health <= 0)
        {
            if(Random.value > 0.5)
            {
                Instantiate(grave, transform.position, transform.rotation);
            }
            deathPlayer.clip = deathSound;
            deathPlayer.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().gameOver = true;
            Debug.Log("Game Over!");
        }

        if (collision.gameObject.CompareTag("Skeleton"))
        {
            health -= collision.gameObject.GetComponent<SkeletonScript>().damage;
            speed *= -1;
            facingRight = !facingRight;
            sr.flipX = !sr.flipX;

            audioPlayer.clip = hitSound;
            audioPlayer.Play();
        }

        if (collision.gameObject.CompareTag("Villager"))
        {
            speed *= -1;
            facingRight = !facingRight;
            sr.flipX = !sr.flipX;
        }
    }
}
