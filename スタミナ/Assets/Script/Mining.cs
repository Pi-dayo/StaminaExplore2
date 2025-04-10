using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    Animator animator;
    AttackAnim attackAnim;
    PickAxeAnim pickAxeAnim;

    bool isMining = false;//�̌@�����ǂ���
    bool moveRestriction = false;//�A�N�V�����S��
    float coolTime = 1;
    float timer;
    float moveRestrictionTime = 0.5f;//�S������
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
        //���N���b�N���̌@������Ȃ�����Ƀs�b�P���������Ă�����
        if (Input.GetMouseButtonDown(0) && !isMining && GameObject.Find("PickAxe") != null)
        {
            isMining = true;//�̌@�����I��
            moveRestriction = true;//�S�������I��
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
        //�S�����Ԃ��߂�����S������
        if (timer > moveRestrictionTime)
        {
            moveRestriction = false;
        }
    }

}
