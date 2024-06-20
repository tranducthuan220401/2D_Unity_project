using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Land : MonoBehaviour
{
    public float floatSpeed = 0.5f;
    public float amplitude = 0.5f;
    public bool vertical = true; 
    private Vector3 startPos;
    public bool fly = true;
    public bool transHorizontal;
    void Start()
    {
        startPos = transform.position;
    }
    public bool isFly()
    {
        return fly;
    }
    
    void Update()
    {
      
        if (fly)
        {
            Vector3 newPos;
            float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * amplitude;
            float newX = startPos.x + Mathf.Sin(Time.time * floatSpeed) * amplitude;
            if (transHorizontal)
            {
                newPos = new Vector3(newX, startPos.y, startPos.z);
            }
            else
            {
                newPos = new Vector3(startPos.x, newY, startPos.z);

            }
            if (vertical)
            {
                transform.position = newPos;
            }
            else
            {
                transform.position = new Vector3(newPos.x, startPos.y, newPos.z);
            }
        }
        else
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}
