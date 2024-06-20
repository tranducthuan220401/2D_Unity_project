using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Rope : MonoBehaviour
{
    public GameObject baloon, land;
    Fly_Land fly_Land;
    float flyGravity = -0.5f;
    float fallGravity = 0.5f;
    private void Start()
    {
        fly_Land = FindObjectOfType<Fly_Land>();
    }
    void OnMouseDown()
    {
        Cut();
    }
    public void Cut()
    {
        Rigidbody2D baloon2D = baloon.GetComponent<Rigidbody2D>();
        Rigidbody2D land2D = land.GetComponent<Rigidbody2D>();
        baloon2D.gravityScale = flyGravity;
        land2D.gravityScale = fallGravity;
        fly_Land.fly = false;
    }
}
