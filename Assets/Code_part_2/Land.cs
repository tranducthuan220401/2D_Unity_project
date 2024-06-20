using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    Boolean isEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool getIsEntered()
    {
        return isEntered;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isEntered = true;
            Rigidbody2D body2D = gameObject.GetComponent<Rigidbody2D>();
            body2D.constraints = RigidbodyConstraints2D.FreezePositionY | body2D.constraints;
        }
    }

}
