using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    Attack attack;
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        attack = GameObject.Find("Player").GetComponent<Attack>();
        boxCollider2D=GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attack.IsAttack)
        {
            boxCollider2D.enabled=true;
        }
        if(!attack.MoveRestriction)
        {
            boxCollider2D.enabled=false;
        }
    }
}
