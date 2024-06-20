using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;

public class Key_Script : invisible_Class
{
    [SerializeField] private float speed = 2f;
    public int clickLimit;
    public Transform door;

    private int boxNumber;
    private Vector2 clickPos;
    private bool isOpen = false;
    private int currentClick = 0;

    // Start is called before the first frame update
    void Start()
    {
        boxNumber = Random.Range(1, clickLimit);
        DisableSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            KeyMove();
        }
    }

    public void RandomOpen(Vector2 ClickPosition)
    {
            int RandomNuumber = Random.Range(0, clickLimit);
            currentClick++;
            if (RandomNuumber == boxNumber || currentClick == clickLimit)
            {
                transform.position = ClickPosition;
                EnableSprite();
                isOpen = true;
            }
    }

    private void KeyMove()
    {
        if (door != null)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, door.position, speed * Time.deltaTime);
            transform.position = newPosition;
            if (Vector3.Distance(transform.position, door.position) <= 0.1f)
            {
                door.GetComponent<Door_Scipt>().OpenDoor();
                isOpen = false;
                Destroy(gameObject);
            }
        }
    }
}
