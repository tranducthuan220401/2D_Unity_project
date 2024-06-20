using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jung1_Controller : AController
{
    PickExe pickExe;
    Key key;
    public Move_Item endCrystal;
    bool keyStateSet = false;
    bool crystalStateSet = false;
    EndMarkPortal endMarkPortal;
    


    public override void Start()
    {
        pickExe = FindObjectOfType<PickExe>();
        key = FindObjectOfType<Key>();
        endMarkPortal = FindObjectOfType<EndMarkPortal>();
    }

    public override void Update()
    {
        if (!keyStateSet)
        {
            if (!key.canClick && pickExe.endMark)
            {
                key.canClick = true;
                keyStateSet = true;
            }
        }
        if (!crystalStateSet)
        {
            if (endCrystal.endMark) {
                endMarkPortal.visible = true;
            }
        }
        if (isWin && portalCondition)
        {
            frog.moving = true;
            
            return;
        }
    }
}
