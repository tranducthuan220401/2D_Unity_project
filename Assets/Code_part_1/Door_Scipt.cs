using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door_Scipt : MonoBehaviour
{
    private bool isOpen = false;
    private Animator an;
    private BoxCollider2D cl;

    // Start is called before the first frame update
    void Start()
    {
        an = transform.GetComponent<Animator>();
        cl = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && an != null && cl != null)
        {
            an.Play("Door_open");
            cl.isTrigger = true;
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}
