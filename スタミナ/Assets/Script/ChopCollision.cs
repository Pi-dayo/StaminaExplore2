using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopCollision : MonoBehaviour
{
    Chop chop;
    BoxCollider2D boxCollider2D;
    float timer;
    float collisionStartTime = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        chop = GameObject.Find("Player").GetComponent<Chop>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (chop.IsChop)
        {
            timer += Time.deltaTime;
            if (timer > collisionStartTime)
            {
                boxCollider2D.enabled = true;
            }
        }
        if (!chop.MoveRestriction)
        {
            boxCollider2D.enabled = false;
            timer = 0;
        }
    }
}
