using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Click_Script : MonoBehaviour
{
    [System.Serializable]
    public class Vector2Event : UnityEvent<Vector2> { }

    public Vector2Event click;
    public bool repeat = false;

    private bool isClick = false;
    private bool clickCheck = true;

    // Update is called once per frame
    void Update()
    {
        if (isClick && clickCheck)
        {
            click.Invoke(transform.position);
            clickCheck = false;
            if (repeat)
            {
                isClick = false;
                clickCheck = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isClick) isClick = true;
    }
}
