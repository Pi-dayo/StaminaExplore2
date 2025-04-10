using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnim : MonoBehaviour
{
    Animator animator;
    Attack attack;


    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        attack = GameObject.Find("Player").GetComponent<Attack>();
    }
    public void IsAttack(bool isAttack)
    {
        animator.SetBool("attack",isAttack);
    }

}
