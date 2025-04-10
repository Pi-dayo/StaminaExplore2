using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo : MonoBehaviour
{
    [SerializeField] float collisionX;
    [SerializeField] float collisionY;
    [SerializeField] float destroyTime;
    [SerializeField] string EffectName;
    Animator animator;
    BoxCollider2D boxCollider;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(EffectName);
        transform.parent = null;
        transform.localScale = new Vector2(collisionX, collisionY);
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > destroyTime)
        {
            Destroy(gameObject);
        }
    }

    public void CollisionStart()
    {
        boxCollider.enabled = true;
    }
    public void CollisionEnd()
    {
        boxCollider.enabled = false;
    }
}
