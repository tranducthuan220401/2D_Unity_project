using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Move_Hook : MonoBehaviour
{
    [SerializeField] private List<Transform> movePoss;
    [SerializeField] private bool moving = false;
    public float hookSpeed = 1f;
    public Transform lever;
    public bool autoDrop = false;

    private bool touching;
    private Grab_Item gi;
    private Vector2 initialPos;
    private bool back = false;
    private int currentIndex = 0;
    private string currentStage;

    void Start()
    {
        gi = transform.GetComponent<Grab_Item>();
        initialPos = transform.position;

        for (int i = 0; i < movePoss.Count; i++)
        {
            if (movePoss[i] == null)
            {
                movePoss.RemoveAt(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        touching = gi.touching;

        if (currentIndex < 0)
        {
            currentIndex = 0;
        }
        if (movePoss.Count > 0 && moving && currentStage != "Lever_off")
        {
            currentIndex = 0;
            moving = false;
            currentStage = "Lever_on";
            ChangeStage(currentStage);
            StartCoroutine(MoveToNextPosition());
        }
        if (touching || back)
        {
            StartCoroutine(MoveBackToNextPosition());
            back = false;
        }
    }

    IEnumerator MoveToNextPosition()
    {
        while (currentIndex < movePoss.Count)
        {
            Transform target = movePoss[currentIndex];

            while (transform.position != target.position && !touching)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, hookSpeed * Time.deltaTime);
                yield return null;
            }

            if (currentIndex == movePoss.Count - 1 || touching)
            {
                back = true;
                currentIndex = movePoss.Count - 1 - (movePoss.Count - currentIndex);
                yield break;
            }

            currentIndex++;
        }
    }

    IEnumerator MoveBackToNextPosition()
    {
        if (back)
        {
            while (currentIndex >= 0)
            {
                Vector2 targetPosition = movePoss[currentIndex].position;
                while ((Vector2)transform.position != targetPosition)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPosition, hookSpeed * Time.deltaTime);
                    yield return null;
                }
                if (currentIndex == 0)
                {
                    yield return MoveToBasePosition();
                    yield break;
                }
                currentIndex--;
            }
        }
    }

    IEnumerator MoveToBasePosition()
    {
        while ((Vector2)transform.position != initialPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPos, hookSpeed * Time.deltaTime);
            yield return null;
        }
        if (autoDrop) DropItem();
        if(!touching) ChangeStage("Lever_off");
    }

    void DropItem()
    {
        if (touching)
        {
            gi.Drop();
            ChangeStage("Lever_off");
        }
    }

    private void OnMouseDown()
    {
        DropItem();
    }

    public void Move()
    {
        if(((Vector2)transform.position == initialPos)) moving = true;
    }

    void ChangeStage(string stage)
    {
        if (lever != null)
        {
            lever.GetComponent<Lever_Scipt>().ChangeStage(stage);
        }
    }
}
