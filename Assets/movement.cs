using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Referanser
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D coll;
    [SerializeField] private Transform groundCheck;

    // Inputs
    private float move;
    private bool jump;

    // Horisontal bevegelse
    private float moveDir = 0;
    public float movementSpeed = 12f;
    private float currentSpeed = 1f;
    public float acceleration = 5f;
    private readonly float accelerationControl = 0.01f;

    // Vertical bevegelse
    private bool isJumping;
    public float jumpForce = 10;
    private float gravityScale;
    private float jumpBuffering = 0.15f;
    private float jumpBufferingCounter = 0f;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter = 0f;

    // Checks
    public bool isGrounded;
    private Vector2 checkSize = new Vector2(0.4f, 0.1f);
    public LayerMask groundMask;

    void Start() 
    {
        gravityScale = rb.gravityScale;
    }

    void FixedUpdate()
    {
        // Horisontal bevegelse
        if (move != 0) 
        {
            if (currentSpeed < movementSpeed)
            {
                currentSpeed += acceleration * accelerationControl;
            }
            else
            {
                currentSpeed = movementSpeed;
            }
            Debug.Log("Movign");
        }

        rb.velocity = new Vector2(moveDir * currentSpeed, rb.velocity.y);
        

        // Vertikal bevegelse
        if (isJumping && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
            isGrounded = false;
        }
    }
    
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        jump = Input.GetKey("space");

        if (move != 0)
        {
            float previousDir = moveDir;
            moveDir = move;
            if (previousDir != moveDir)
            {
                currentSpeed = movementSpeed * 0.5f;
            }
        }
        else
        {
            moveDir = 0;
            currentSpeed = 1;
        }

        if (jump)
        {
            jumpBufferingCounter = jumpBuffering;
        }
        else
        {
            jumpBufferingCounter -= Time.deltaTime;
        }

        if (jumpBufferingCounter > 0)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (Physics2D.OverlapBox(new Vector2(groundCheck.position.x, groundCheck.position.y), checkSize, 0, groundMask))
        {
            isGrounded = true;
            coyoteTimeCounter = coyoteTime;
        }
        else if (!Physics2D.OverlapBox(new Vector2(groundCheck.position.x, groundCheck.position.y), checkSize, 0, groundMask) && rb.velocity.y < 0)
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter < 0) 
        {
            isGrounded = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = gravityScale * 2;
        }
        else
        {
            rb.gravityScale = gravityScale;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(groundCheck.position.x, groundCheck.position.y, groundCheck.position.z), new Vector3(checkSize.x, checkSize.y, 0));
    }


}
