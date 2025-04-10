using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPlayerParts : MonoBehaviour
{
    [SerializeField] PlayerArmor playerStroyParts;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Up()
    {
        spriteRenderer.sprite = playerStroyParts.sprite[0];
    }
    public void UpRight()
    {
        spriteRenderer.sprite = playerStroyParts.sprite[1];
    }
    public void Right()
    {
        spriteRenderer.sprite = playerStroyParts.sprite[2];
    }
    public void DownRight()
    {
        spriteRenderer.sprite = playerStroyParts.sprite[3];
    }
    public void Down()
    {
        spriteRenderer.sprite = playerStroyParts.sprite[4];
    }
    public void DownLeft()
    {
        spriteRenderer.sprite = playerStroyParts.sprite[5];
    }
    public void Left()
    {
        spriteRenderer.sprite = playerStroyParts.sprite[6];
    }
    public void UpLeft()
    {
        spriteRenderer.sprite = playerStroyParts.sprite[7];
    }
}
