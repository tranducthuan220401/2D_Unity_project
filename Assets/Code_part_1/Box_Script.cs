using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_script : MonoBehaviour
{
    private bool isHolding = false;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    public void Holding()
    {
        isHolding = true;
    }

    public void UnHolding()
    {
        isHolding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("DeadObject"))
        //{
        //    collision.GetComponent<Collider2D>().isTrigger = true;
        //    Debug.Log(collision.transform);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Frog"))
        {
            collision.transform.SetParent(transform);
        }
        if (collision.gameObject.CompareTag("DeadObject"))
        {
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Frog"))
        {
            collision.transform.SetParent(null);
        }
    }
}
