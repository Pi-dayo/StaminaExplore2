using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeAnim : MonoBehaviour
{
    Animator animator;
    Mining mining;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mining = GameObject.Find("Player").GetComponent<Mining>();
    }
    public void IsMining(bool mining)
    {
        animator.SetBool("mining", mining);
    }
}
