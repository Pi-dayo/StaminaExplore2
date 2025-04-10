using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    Animator animator;
    AttackAnim attackAnim;
    PickAxeAnim pickAxeAnim;

    bool isMining = false;//採掘中かどうか
    bool moveRestriction = false;//アクション拘束
    float coolTime = 1;
    float timer;
    float moveRestrictionTime = 0.5f;//拘束時間
    public bool IsMining { get => isMining; }
    public bool MoveRestriction { get => moveRestriction; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //左クリックかつ採掘中じゃないかつ手にピッケルを持っていたら
        if (Input.GetMouseButtonDown(0) && !isMining && GameObject.Find("PickAxe") != null)
        {
            isMining = true;//採掘中をオン
            moveRestriction = true;//拘束中をオン
                pickAxeAnim = GameObject.Find("PickAxe").GetComponent<PickAxeAnim>();
                pickAxeAnim.IsMining(isMining);
            animator.SetBool("mining", isMining);
        }
        if (isMining)
        {
            timer += Time.deltaTime;
        }
        if (timer > coolTime)
        {
            isMining = false;
            timer = 0;
            if (GameObject.Find("PickAxe") != null)
            {
                pickAxeAnim = GameObject.Find("PickAxe").GetComponent<PickAxeAnim>();
                pickAxeAnim.IsMining(isMining);
            }
            animator.SetBool("mining", isMining);
        }
        //拘束時間を過ぎたら拘束解除
        if (timer > moveRestrictionTime)
        {
            moveRestriction = false;
        }
    }

}
