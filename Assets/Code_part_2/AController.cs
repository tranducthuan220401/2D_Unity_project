using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AController : MonoBehaviour
{
    public bool isOver = false;
    public bool isWin = false;
    public Scene sceneLoaded;
    public Frog_Movement frog;
    public bool portalCondition = false;
    public abstract void Start();
   
    public abstract void Update();
    public void toNextScene()
    {
        if (isWin)
        {
            try
            {
                sceneLoaded = SceneManager.GetActiveScene();
                SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
            }catch(Exception e)
            {
                Debug.Log(e.Message);

            }
        }
    }
}
