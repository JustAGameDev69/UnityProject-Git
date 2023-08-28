using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private int inputX;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        playerMove();
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

}
