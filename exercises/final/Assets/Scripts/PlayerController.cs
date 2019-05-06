using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public Transform dartSpawn;

    public GameObject ropeHingeAnchor;
    public DistanceJoint2D ropeJoint;
    private bool ropeAttached;
    private Vector2 playerPosition;
    private Rigidbody2D ropeHingeAnchorRb;
    private SpriteRenderer ropeHingeAnchorSprite;

    public LineRenderer ropeRenderer;
    public LayerMask ropeLayerMask;
    public float ropeMaxDistance = 20f;
    private List<Vector2> ropePositions = new List<Vector2>();

    private bool distanceSet;

    public float immunity;

    public GameObject gameManager;

    public AudioClip jump;
    public AudioSource audioPlayer;
    public AudioClip hook;
    public AudioSource hookPlayer;

    private void Awake()
    {
        ropeJoint.enabled = false;
        playerPosition = transform.position;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        immunity = 0;

        audioPlayer.clip = jump;
        hookPlayer.clip = hook;
    }

    void FixedUpdate()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            //Ground check
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            //Movement
            moveInput = Input.GetAxis("Horizontal");
            rb.AddForce(new Vector2((moveInput * speed - rb.velocity.x) * speed, 0));
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);

            //Flip sprite
            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }

    }

    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            //Immune after hit
            if (immunity > 0f)
            {
                immunity -= Time.deltaTime;
                Debug.Log(immunity);
            }
            if (immunity < 0f)
            {
                immunity = 0f;
            }

            //Jumping
            if (isGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = Vector2.up * jumpForce;
                    audioPlayer.Play();
                }
            }

            //Aim mouse
            var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            var facingDirection = worldMousePosition - transform.position;
            var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
            if (aimAngle < 0f)
            {
                aimAngle = Mathf.PI * 2 + aimAngle;
            }

            var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;

            playerPosition = transform.position;

            HandleInput(aimDirection);
            UpdateRopePosition();
            if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                audioPlayer.Play();
            }
        }
    }

    //Grappling hook
    private void HandleInput(Vector2 aimDirection)
    {
        if (Input.GetMouseButton(0))
        {
            if (ropeAttached)
            {
                rb.AddForce(new Vector2(dartSpawn.transform.position.x - transform.position.x, dartSpawn.transform.position.y - transform.position.y), ForceMode2D.Impulse);
            }
            else
            {
                ropeRenderer.enabled = true;

                var hit = Physics2D.Raycast(playerPosition, aimDirection, ropeMaxDistance, ropeLayerMask);

                if (hit.collider != null)
                {
                    ropeAttached = true;
                    if (!ropePositions.Contains(hit.point))
                    {
                        rb.AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
                        ropePositions.Add(hit.point);
                        ropeJoint.distance = Vector2.Distance(playerPosition, hit.point);
                        ropeJoint.enabled = true;
                        ropeHingeAnchorSprite.enabled = true;
                        hookPlayer.Play();
                    }

                }
                else
                {
                    ropeRenderer.enabled = false;
                    ropeAttached = false;
                    ropeJoint.enabled = false;
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            ResetRope();
        }
        
    }

    //Reset grappling hook
    private void ResetRope()
    {
        ropeJoint.enabled = false;
        ropeAttached = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;
    }

    //Draw rope
    private void UpdateRopePosition()
    {
        if (!ropeAttached)
        {
            return;
        }

        ropeRenderer.positionCount = ropePositions.Count + 1;

        for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
        {
            if (i != ropeRenderer.positionCount - 1)
            {
                ropeRenderer.SetPosition(i, ropePositions[i]);

                if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                {
                    var ropePosition = ropePositions[ropePositions.Count - 1];
                    if (ropePositions.Count == 1)
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                    else
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                }
                else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                {
                    var ropePosition = ropePositions.Last();
                    ropeHingeAnchorRb.transform.position = ropePosition;
                    if (!distanceSet)
                    {
                        ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                        distanceSet = true;
                    }
                }
            }
            else
            {
                ropeRenderer.SetPosition(i, transform.position);
            }
        }
    }

    //Flip sprite
    void Flip()
    {
        facingRight = !facingRight;
        sr.flipX = !sr.flipX;
    }

}
