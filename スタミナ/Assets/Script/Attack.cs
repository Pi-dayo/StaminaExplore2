using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    AttackAnim attackAnim;
    bool isAttack = false;
    bool moveRestriction=false;//拘束中かどうか
    float coolTime=1;//クールタイム
    float timer;
    float moveRestrictionTime=0.5f; //攻撃硬直
    public bool IsAttack { get => isAttack;}
    public bool MoveRestriction { get => moveRestriction; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //左クリックかつアタック中じゃないかつSowrdを手に持っていたら
        if (Input.GetMouseButtonDown(0)&&!isAttack&& GameObject.Find("Sword") != null)
        {
            //アタック中にして拘束をオン
            isAttack = true;
            moveRestriction = true;

                attackAnim= GameObject.Find("Sword").GetComponent<AttackAnim>();
                attackAnim.IsAttack(isAttack);
            animator.SetBool("attack",isAttack);//剣攻撃アニメーション
        }
        if (isAttack)//攻撃中ならクールダウンタイマー起動
        {
            timer += Time.deltaTime;
        }
        if (timer > coolTime)//クールタイムを過ぎたら
        {
            isAttack=false;//攻撃中解除
            timer = 0;
            if (GameObject.Find("Sword") != null)
            {
                attackAnim = GameObject.Find("Sword").GetComponent<AttackAnim>();
                attackAnim.IsAttack(isAttack);
            }
            animator.SetBool("attack", isAttack);
        }
        //攻撃拘束時間を過ぎたら拘束解除
        if (timer>moveRestrictionTime) {
            moveRestriction=false;
        }
    }

}
