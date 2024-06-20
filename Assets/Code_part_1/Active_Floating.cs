using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Active_Floating : MonoBehaviour
{
    public LayerMask objectLayer;
    [SerializeField] private Transform triggerGameobject;

    private bool isFloating = false;
    private Transform floatingOject;
    private Vector2 point;

    private void Update()
    {
        if (isFloating)
        {
            float elapsedTime = Time.time;

            float yOffset = Mathf.Sin(elapsedTime * 3f) * 0.05f;

            Vector2 newPosition = point + new Vector2(0f, yOffset);

            floatingOject.position = newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlockObject") && !isFloating)
        {
            floatingOject = collision.transform;
            point = collision.transform.position - new Vector3(0,0.3f,0);
            triggerGameobject.gameObject.SetActive(false);
            isFloating = true;
            collision.gameObject.tag = "FloatingObject";
            collision.gameObject.layer = LayerMask.NameToLayer("Ground");
        }
    }
}
