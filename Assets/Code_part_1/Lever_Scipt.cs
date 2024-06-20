using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class Lever_Scipt : MonoBehaviour
{
    public UnityEvent leverOn;

    private string currentStage = "Lever_off";
    private Animator an;

    // Start is called before the first frame update
    void Start()
    {
        an = transform.GetComponent<Animator>();
        ChangeStage(currentStage);
    }

    private void OnMouseDown()
    {
        ChangeStage("Lever_on");
        leverOn.Invoke();
    }

    public void ChangeStage(string stage)
    {
        if (stage == currentStage) return;
        else
        {
            currentStage = stage;

            an.Play(stage);
        }
    }
}
