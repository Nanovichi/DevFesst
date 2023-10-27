using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float direction;
    [SerializeField]
    private float speed, jumpforce, radius;

    [SerializeField]
    private GameObject GroundCheck;
    [SerializeField]
    private LayerMask GroundLayer;
    private Animator animator;
    [SerializeField]
    private Transform respawn;
    private SpriteRenderer sprite;
    [SerializeField]
    private LeveLoader leveLoader;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {

    }
    private void Update()
    {

        Moving();
        Jump();
        animator.SetBool("IsJumping", !IsGrounded());
    }

    private void Moving()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            if (direction > 0)
            {
                sprite.flipX = false;
            }
            else if (direction < 0)
            {
                sprite.flipX = true;
            }
            animator.SetBool("IsWalking", true);

        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        Vector2 movement = new Vector2(direction, 0);
        this.rb.velocity = new Vector2(movement.x * speed, this.rb.velocity.y);

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            
            this.rb.AddForce(jumpforce * Vector2.up, ForceMode2D.Impulse);
            Debug.Log("Jumping");
        }
    }
    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, radius, GroundLayer);
        Debug.Log(isGrounded);
        return Physics2D.OverlapCircle(GroundCheck.transform.position, radius, GroundLayer);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pikes"))
        {
            Debug.Log("death");
            this.transform.position = respawn.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            leveLoader.LoadNextLevel();
        }
    }
}
