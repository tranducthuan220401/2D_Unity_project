using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool canClick = false;
    public Move_Item move_item;
    public GameObject chest;
    public List<GameObject> chestItem;
    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (canClick)
        {
            move_item.enableToCLick = true;
            canClick = false;
        }
        if (move_item.endMark)
        {
            chest.GetComponent<Animator>().SetBool("endmark", true);
            StartCoroutine(Delay(1f));
            chest.SetActive(false);
            foreach (var item in chestItem)
            {
                item.gameObject.SetActive(true);
            }
            return;
        }
    }
}
