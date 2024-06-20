using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject messBox;

    private float clickCooldown = 1.5f;
    private float lastClickTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (messBox != null)
        {
            messBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastClickTime >= clickCooldown)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray2D ray = new Ray2D(mousePosition, Vector2.zero);

            lastClickTime = Time.time;

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.CompareTag("ClickedObject"))
            {
                Debug.Log("Click: " + hit.collider.gameObject.name);
            }
            else
            {
                messBox.SetActive(true);

                Invoke("Close", 1.5f);
            }
        }
    }

    void Close()
    {
        messBox.SetActive(false);
    }
}
