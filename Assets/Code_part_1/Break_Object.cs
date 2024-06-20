using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Break_Object : invisible_Class
{
    [SerializeField] private float speed;
    public Transform objectDestroyed;

    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        DisableSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Break();
        }
    }

    public void Move(Vector2 ClickPostion)
    {
        transform.position = ClickPostion;
        EnableSprite();
        isMoving = true;
    }
    private void Break()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, objectDestroyed.position, speed * Time.deltaTime);
        transform.position = newPosition;
        if (Vector3.Distance(transform.position, objectDestroyed.position) <= 0.1f)
        {
            Destroy(objectDestroyed.gameObject);
            Destroy(gameObject);
        }
    }
}
