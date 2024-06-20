using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EndMarkPortal : MonoBehaviour
{
    public AController controller;
    public bool visible = false;
    public GameObject crysto;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (visible)
        {
            crysto.SetActive(false);
            animator.SetBool("endmark", true);
            controller.isWin = true;
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            _ = delay();
            controller.toNextScene();
        }
    }
    private async Task delay()
    {
        await Task.Delay(1000);
    }
}
