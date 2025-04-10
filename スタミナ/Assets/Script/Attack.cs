using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    AttackAnim attackAnim;
    bool isAttack = false;
    bool moveRestriction=false;//�S�������ǂ���
    float coolTime=1;//�N�[���^�C��
    float timer;
    float moveRestrictionTime=0.5f; //�U���d��
    public bool IsAttack { get => isAttack;}
    public bool MoveRestriction { get => moveRestriction; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //���N���b�N���A�^�b�N������Ȃ�����Sowrd����Ɏ����Ă�����
        if (Input.GetMouseButtonDown(0)&&!isAttack&& GameObject.Find("Sword") != null)
        {
            //�A�^�b�N���ɂ��čS�����I��
            isAttack = true;
            moveRestriction = true;

                attackAnim= GameObject.Find("Sword").GetComponent<AttackAnim>();
                attackAnim.IsAttack(isAttack);
            animator.SetBool("attack",isAttack);//���U���A�j���[�V����
        }
        if (isAttack)//�U�����Ȃ�N�[���_�E���^�C�}�[�N��
        {
            timer += Time.deltaTime;
        }
        if (timer > coolTime)//�N�[���^�C�����߂�����
        {
            isAttack=false;//�U��������
            timer = 0;
            if (GameObject.Find("Sword") != null)
            {
                attackAnim = GameObject.Find("Sword").GetComponent<AttackAnim>();
                attackAnim.IsAttack(isAttack);
            }
            animator.SetBool("attack", isAttack);
        }
        //�U���S�����Ԃ��߂�����S������
        if (timer>moveRestrictionTime) {
            moveRestriction=false;
        }
    }

}
