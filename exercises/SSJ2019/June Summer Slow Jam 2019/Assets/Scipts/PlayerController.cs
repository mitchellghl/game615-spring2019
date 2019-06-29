using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public float drag;

    private Rigidbody2D rb;

    private SpriteRenderer sr;
    public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public GameObject gameManager;

    public bool channeling;

    public bool gameOver = false;
    public GameObject magicAttack;

    public AudioClip jumpSound;
    public AudioSource audioPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audioPlayer.clip = jumpSound;
    }

    private void FixedUpdate()
    {
        //Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Movement
        moveInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2((moveInput * speed - rb.velocity.x) * speed, 0));
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);

        if (moveInput != 0)
        {
            moveInput = moveInput / drag;
        }

        //Flip Sprite
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        //Jumping
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector2.up * jumpForce;
                audioPlayer.Play();
            }
        }

        //Attack
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(magicAttack, transform.position, transform.rotation);
        }

        //Channeling
        if (Input.GetKey(KeyCode.C))
        {
            channeling = true;
        } else
        {
            channeling = false;
        }

    }

    //Flip Sprite Function
    void Flip()
    {
        facingRight = !facingRight;
        sr.flipX = !sr.flipX;
    }
}
