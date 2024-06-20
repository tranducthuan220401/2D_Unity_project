using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Tower_Crystal : MonoBehaviour
{
    public GameObject symmetryCrystal, hiddenObject;
    public bool IsLast;
    public AController controller;
    public async Task ShowAsync() {
        symmetryCrystal.SetActive(true);
        gameObject.SetActive(false);
        if (hiddenObject!=null)
            {
                hiddenObject.SetActive(true);

            foreach (Transform childTransform in hiddenObject.transform)
            {
                GameObject child = childTransform.gameObject;
                await Task.Delay(200);
                child.SetActive(true);
             
            }
        }
         
        
 
    }
   
    private void OnMouseDown()
    {

        if (!IsLast)
        {
            _ = ShowAsync();
        }
        else
        {
            controller.portalCondition = true;
        }
    }
}
