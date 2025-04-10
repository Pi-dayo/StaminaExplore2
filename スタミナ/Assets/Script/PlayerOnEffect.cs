using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnEffect : MonoBehaviour
{
    [SerializeField] bool isFlip;
    [SerializeField] GameObject playerOnEffect;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (!isFlip)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
            Instantiate(playerOnEffect, transform);
        }
    }
}
