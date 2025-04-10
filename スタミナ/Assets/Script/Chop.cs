using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chop : MonoBehaviour
{
    Animator animator;
    AttackAnim attackAnim;
    AxeAnim AxeAnim;
    bool isChop = false;//斧ふり中かどうか
    bool moveRestriction = false;//アクション拘束
    float coolTime = 1.2f;
    float timer;
    float moveRestrictionTime = 1;//拘束時間
    public bool IsChop { get => isChop; }
    public bool MoveRestriction { get => moveRestriction; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //左クリックかつ斧ふり中じゃないかつ手に斧を持っていたら
        if (Input.GetMouseButtonDown(0) && !isChop && GameObject.Find("Axe") != null)
        {
            isChop = true; //斧ふり中をオン
            moveRestriction = true;//拘束をオン
                AxeAnim = GameObject.Find("Axe").GetComponent<AxeAnim>();
                AxeAnim.IsChop(isChop);
            animator.SetBool("chop", isChop);
        }
        //斧ふり中ならクールタイムタイマーオン
        if (isChop)
        {
            timer += Time.deltaTime;
        }
        if (timer > coolTime)
        {
            isChop = false;
            timer = 0;
            if (GameObject.Find("Axe") != null)
            {
                AxeAnim = GameObject.Find("Axe").GetComponent<AxeAnim>();
                AxeAnim.IsChop(isChop);
            }
            animator.SetBool("chop", isChop);
        }
        //拘束時間を過ぎたら拘束解除
        if (timer > moveRestrictionTime)
        {
            moveRestriction = false;
        }
    }
}
