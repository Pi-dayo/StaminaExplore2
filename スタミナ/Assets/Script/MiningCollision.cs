using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningCollision : MonoBehaviour
{
    Mining mining;
    BoxCollider2D boxCollider2D;
    float timer;
    float collisionStartTime=0.3f;
    // Start is called before the first frame update
    void Start()
    {
        mining = GameObject.Find("Player").GetComponent<Mining>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mining.IsMining)
        {
            timer+=Time.deltaTime;
            if (timer > collisionStartTime)
            {
                boxCollider2D.enabled = true;
            }
        }
        if (!mining.MoveRestriction)
        {
            boxCollider2D.enabled = false;
            timer = 0;
        }
    }
}
