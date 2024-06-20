using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker_Trap : MonoBehaviour
{
    public float toggleInterval = 1f;
    public GameObject trap;
    public AController controller;
    private void Start()
    {
        StartCoroutine(ToggleObject());
    }

    private IEnumerator ToggleObject()
    {
        bool activeStatus = true;
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);
            activeStatus = !activeStatus;
            trap.SetActive(activeStatus);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.isOver = true;
            return;
        }
     
    }
}
