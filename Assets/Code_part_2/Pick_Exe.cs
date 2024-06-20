using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickExe : MonoBehaviour
{
    public Move_Item move_item;
    public List<GameObject> blocks;
    public bool endMark = false;

  IEnumerator Delay(float delay)
    {
        endMark = true;
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (move_item.endMark)
        {
           foreach (var block in blocks)
            {
                block.SetActive(false);
            }
            StartCoroutine(Delay(1f));
            return;
          
        }
      
    }
}
