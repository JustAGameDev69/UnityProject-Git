using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private int inputX;

    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    public Animator animator;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerMove();

        animator.SetFloat("Speed", Mathf.Abs(inputX));

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
    }

    void playerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            inputX = -1;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputX = 1;
            spriteRenderer.flipX = false;
        }
        else inputX = 0;

        transform.position = new Vector2(transform.position.x + inputX * speed * Time.deltaTime, transform.position.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;

        animator.SetBool("isJumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

}
