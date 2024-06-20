using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Script : MonoBehaviour
{
    private Animator an;
    private bool currentStage = false;

    // Start is called before the first frame update
    void Start()
    {
        an = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (an != null )
        {
            ChangeStage(!currentStage);
        }
    }

    private void ChangeStage(bool Stage)
    {
        if (Stage == currentStage) return;

        if (Stage)
        {
            an.Play("Bridge_on");
            currentStage = Stage;
        }
        else
        {
            an.Play("Bridge_off");
            currentStage = Stage;
        }
    }
}
