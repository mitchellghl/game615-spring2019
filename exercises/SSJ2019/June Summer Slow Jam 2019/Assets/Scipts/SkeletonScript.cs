using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    public bool facingRight = true;
    public float speed;
    private Rigidbody2D rb;
    public int health;
    public int damage;
    private SpriteRenderer sr;
    public GameObject player;

    public AudioClip spawnSound;
    public AudioClip deathSound;
    public AudioSource audioPlayer;
    public AudioSource deathPlayer;
    public GameObject deathSounds;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManagerScript>().score += 5;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());

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
            deathPlayer.clip = deathSound;
            deathPlayer.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Villager"))
        {
            health -= collision.gameObject.GetComponent<VillagerScript>().damage;
            speed *= -1;
            facingRight = !facingRight;
            sr.flipX = !sr.flipX;
        }

        if (collision.gameObject.CompareTag("Skeleton"))
        {
            speed *= -1;
            facingRight = !facingRight;
            sr.flipX = !sr.flipX;
        }
    }
}
