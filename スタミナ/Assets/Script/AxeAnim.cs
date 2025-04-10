using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnim : MonoBehaviour
{
    Animator animator;
    Mining mining;
    void Start()
    {
        animator = GetComponent<Animator>();
        mining = GameObject.Find("Player").GetComponent<Mining>();
    }
    public void IsChop(bool chop)
    {
        animator.SetBool("chop", chop);
    }
}
