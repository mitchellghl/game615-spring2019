using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 60f;
    public float jumpForce = 0.35f;

    public float gravityModifier = 0.2f;
    float yVelocity = 0f;
    bool previousIsGroundedValue;

    CharacterController cc;

    float camLookAhead = 5f;
    float camFollowBehind = 10f;
    float camFollowAbove = 5f;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        previousIsGroundedValue = cc.isGrounded;
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
                yVelocity = 0f;
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
    }
}
