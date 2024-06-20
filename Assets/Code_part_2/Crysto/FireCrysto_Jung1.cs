using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireCrysto_Jung1 : ADradAndDrop
{
  

    public override void Update()
    {
    
    }
    private void OnMouseUp()
    {
        isDragging = false;
        if (IsInDropArea(itemTag)) 
        {
            foreach (Transform childTransform in itemReact.transform) 
            {
                GameObject child = childTransform.gameObject;
                if (child.CompareTag("Fire"))
                {

                    StartCoroutine(Delay(1f,child));
                }
            }
        }
    }
    public IEnumerator Delay(float delay,GameObject child)
    {
        child.SetActive(true);
        moveItem.enableToCLick = true;
        yield return new WaitForSeconds(delay);
        itemReact.SetActive(false);
        gameObject.SetActive(false);


    }
}
