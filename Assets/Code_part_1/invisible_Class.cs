using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible_Class : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    public virtual void DisableSprite()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
        }
    }

    public virtual void EnableSprite()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        }
    }
}
