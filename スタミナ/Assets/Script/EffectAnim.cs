using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnim : MonoBehaviour
{

    Animator animator;
    [SerializeField] string animationName;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(animationName);
    }
}
