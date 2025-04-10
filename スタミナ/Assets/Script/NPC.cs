using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] NPCInfo npcInfo;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = npcInfo.NpcDirection[2];
    }

    public void Up()
    {
        spriteRenderer.sprite = npcInfo.NpcDirection[0];
    }
    public void Right()
    {
        spriteRenderer.sprite = npcInfo.NpcDirection[1];
    }
    public void Down()
    {
        spriteRenderer.sprite = npcInfo.NpcDirection[2];
    }
    public void Left()
    {
        spriteRenderer.sprite = npcInfo.NpcDirection[3];
    }
}
