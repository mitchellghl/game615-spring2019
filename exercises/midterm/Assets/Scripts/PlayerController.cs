using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 60f;
    public float jumpForce = 0.35f;

    public float gravityModifier = 0.2f;
    public float yVelocity = 0f;
    bool previousIsGroundedValue;

    CharacterController cc;

    public Vector3 respawnLocation;
    public Vector3 respawnLocation2;

    public float camLookAhead = 8f;
    public float camFollowBehind = 5f;
    public float camFollowAbove = 3f;

    public bool Winner;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        previousIsGroundedValue = cc.isGrounded;
        respawnLocation = transform.position;
        respawnLocation2 = new Vector3(0f,0f,57.5f);
        Winner = false;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);

        if (!cc.isGrounded)
        {
            yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0)
            {
                yVelocity = 0;
            }
        } else
        {
            if (!previousIsGroundedValue)
            {
                yVelocity = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }

        Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;
        amountToMove.y = yVelocity;
        cc.Move(amountToMove);
        previousIsGroundedValue = cc.isGrounded;

        Vector3 cameraPosition = transform.position + (Vector3.up * camFollowAbove) + (-transform.forward * camFollowBehind);
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.LookAt(transform.position + transform.forward * camLookAhead);

        if (transform.position.y < -20)
        {
            transform.position = respawnLocation;
        }

        if (Winner)
        {
            transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().startColor = new Color(0, 29, 253, 255);
        }
        
    }
}
