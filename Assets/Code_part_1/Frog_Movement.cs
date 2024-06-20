using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Movement : MonoBehaviour
{
    public LayerMask groundLayer;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    public float jumpDelayTime = 1f;
    public bool moving = false;
    public float groundChackDistance = 0.1f;
    public GameObject deadPrefab;

    private Rigidbody2D rb;
    private Animator an;
    private bool isGrounded = false;
    private float jumpCooldown = 0.8f;
    private float lastJumpTime = 0f;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        an = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (moving && Time.time - lastJumpTime >= jumpCooldown)
        {
            GroundCheck();
            if (isGrounded)
            {
                Jump();
                lastJumpTime = Time.time;
            }
        }
    }
    private void FixedUpdate()
    {
        an.SetFloat("yVelocity", rb.velocity.y);

        if (moving)
        {
            Vector3 worldPosition = transform.position;

            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition);

            bool isInViewport = viewportPosition.x >= 0 && viewportPosition.x <= 1
                && viewportPosition.y >= 0 && viewportPosition.y <= 1;

            if (!isInViewport)
            {
                DeathEvent();
            }
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(moveSpeed, jumpForce);
            an.SetBool("isJumping", true);
        }
    }

    void GroundCheck()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundChackDistance, groundLayer);

        if (hit.collider != null) isGrounded = true;

        else isGrounded = false;
    }

    private void OnMouseDown()
    {
        moving = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.CompareTag("BlockObject"))
        {
            BlockEvent();
        }
        if (collider.CompareTag("DeadObject"))
        {
            DeathEvent();
        }
    }

    void DeathEvent()
    {
        transform.gameObject.SetActive(false);
        GameObject newObject = Instantiate(deadPrefab, transform.position, Quaternion.identity);
        float randomXVelocity = Random.Range(-5f, 5f);
        float randomYVelocity = Random.Range(6f, 7f);

        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(randomXVelocity, randomYVelocity);
        }
    }

    void BlockEvent()
    {
        moving = false;
        transform.GetComponent<ClickManager>().messBox.SetActive(true);
        transform.GetComponent<ClickManager>().messBox.GetComponent<Animator>().Play("MessBox_over");
    }
}
