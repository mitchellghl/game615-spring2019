using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private SpriteRenderer sr;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public GameObject ropeDart;
    GameObject curRopeDart;
    public Transform dartSpawn;
    Vector2 shootDirection;
    public int dartSpeed;
    public bool ammo;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ammo = true;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if(isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dartSpawn.position;
        shootDirection = shootDirection.normalized;

        if (Input.GetMouseButtonDown(0) && ammo)
        {
            curRopeDart = Instantiate(ropeDart, dartSpawn.position, Quaternion.identity);
            Rigidbody2D rdrb = curRopeDart.GetComponent<Rigidbody2D>();
            rdrb.velocity = new Vector2(shootDirection.x * dartSpeed, shootDirection.y * dartSpeed);
            Physics2D.IgnoreCollision(curRopeDart.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            curRopeDart.GetComponent<RopeDartScript>().player = gameObject;
            ammo = false;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        sr.flipX = !sr.flipX;
    }

}
