using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject entrance, exit;
    Frog_Movement frog_Movement;
    Animator entrance_Animator, exit_Animator;
    public bool swapFacing = false;
 
    void Start()
    {
        frog_Movement = FindObjectOfType<Frog_Movement>();
        entrance_Animator = entrance.GetComponent<Animator>();
        exit_Animator = exit.GetComponent<Animator>();
    }

    
    void Update()
    {
      
    }
    IEnumerator ResetAnimation(Collision2D collision)
    {
        
        collision.gameObject.SetActive(false);

        Vector3 currentScale = collision.gameObject.transform.localScale;
        currentScale.x *= -1;
        collision.gameObject.transform.localScale = currentScale;
        collision.gameObject.transform.position = exit.transform.position;
        frog_Movement.isFacingRight = swapFacing;
        yield return new WaitForSeconds(1f);
        collision.gameObject.SetActive(true);
        entrance_Animator.SetBool("touch", false);
        exit_Animator.SetBool("touch", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            entrance_Animator.SetBool("touch", true);
            exit_Animator.SetBool("touch", true);
            if (gameObject.CompareTag(entrance.tag))
            {
                StartCoroutine(ResetAnimation(collision));
            }
          
           
        }
      
    }
}
