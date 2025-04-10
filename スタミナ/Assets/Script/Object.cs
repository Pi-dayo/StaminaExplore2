using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;

    Animator animator;
    float objectHp;
    int spritStateNum;
    [SerializeField] ObjectInfo objectInfo;
    void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spriteRenderer.sprite=objectInfo.Sprite;
        objectHp = objectInfo.Hp;
        if (objectInfo.DamageStateSprites != null)
        {
            spritStateNum = (int)objectHp / objectInfo.DamageStateSprites.Count;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Enum.GetName(typeof(ObjectInfo.AppropriateTools),objectInfo.ApTools))
        {
            objectHp--;
            if (objectHp <= 0)
            {
           
                    Instantiate(destroyEffect, transform);
                Destroy(gameObject);
            }
            else
            {
                if (objectInfo.DamageStateSprites != null)
                {
                    spriteRenderer.sprite = objectInfo.DamageStateSprites[(int)(objectInfo.Hp - objectHp) / spritStateNum];
                    Debug.Log(objectInfo.DamageStateSprites[(int)(objectInfo.Hp - objectHp) / spritStateNum]);
                }
                if (hitEffect != null)
                {
                    Instantiate(hitEffect, transform);
                }
            }
        }
    }
}
