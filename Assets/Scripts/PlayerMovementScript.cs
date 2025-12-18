using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Horizontal movement speed
    public float jumpForce = 10f;       // Force applied when jumping
    public Rigidbody2D rb;              // Reference to Rigidbody2D component


    private float horizontalInput;      // Store horizontal input
    public bool isGrounded;            // Is the player on the ground?
    private bool canDoubleJump;         // Can the player perform a double jump?


    public Transform groundCheck;       // Position to check if grounded
    public float groundCheckRadius = 0.2f; // Radius of ground check circle
    public LayerMask groundLayer;       // Layer considered as ground


    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput2 = Input.GetAxisRaw("Horizontal");




        // Get horizontal input (-1 for left, 1 for right)
        horizontalInput = Input.GetAxisRaw("Horizontal");


        // Flip the player's sprite to face the direction of movement
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 1f); // Face left, 1/5 size
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 1f); // Face right, 1/5 size
        }


        // Check if the player is on the ground (should happen before jump input)
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, groundLayer);



        // Jump input
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                // First jump
                Jump();
                canDoubleJump = false; // Enable double jump
            }
            else if (canDoubleJump)
            {
                // Double jump
                Jump();
                canDoubleJump = false; // Use up double jump
           
            }
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput2));

    }


    void FixedUpdate()
    {
        // Apply horizontal movement using physics (keeps gravity working properly)
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }


    void Jump()
    {
        // Apply vertical velocity for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }


    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

