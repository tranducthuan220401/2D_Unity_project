using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ADradAndDrop : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    public GameObject itemReact;
    public Move_Item moveItem;
    public string itemTag;
    SpriteRenderer spriteRenderer;
    public abstract void Update();
    public string originColor, newColor;
    Color originCl, newCl;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originCl = HexToColor(originColor);
        newCl = HexToColor(newColor);
    }


    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
            _ = changeColorAsync();
        }
    }
    private async Task changeColorAsync()
    {
        if (IsInDropArea(itemTag))
        {
            await Task.Delay(200);
            if (spriteRenderer.color.Equals(originCl))
            {
                spriteRenderer.color = newCl;
            }
            else
            {

                spriteRenderer.color = originCl;
            }
        }
        else
        {
            spriteRenderer.color = originCl;
        }
    }
    public static Color HexToColor(string hexColor)
    {
    
        if (hexColor.Length < 6 || hexColor[0] != '#')
        {
            return Color.white; 
        }

       
        Color color;
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            return color; 
        }
        else
        {
         
            return Color.white; 
        }
    }
    private void OnMouseUp()
    {
        isDragging = false;
       
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    public bool IsInDropArea(string tagName)
    {
       
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(tagName))
            {
                return true;
            }
        }
        return false;
    }
   
}
