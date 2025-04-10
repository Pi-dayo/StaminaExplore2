using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chop : MonoBehaviour
{
    Animator animator;
    AttackAnim attackAnim;
    AxeAnim AxeAnim;
    bool isChop = false;//���ӂ蒆���ǂ���
    bool moveRestriction = false;//�A�N�V�����S��
    float coolTime = 1.2f;
    float timer;
    float moveRestrictionTime = 1;//�S������
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
        //���N���b�N�����ӂ蒆����Ȃ�����ɕ��������Ă�����
        if (Input.GetMouseButtonDown(0) && !isChop && GameObject.Find("Axe") != null)
        {
            isChop = true; //���ӂ蒆���I��
            moveRestriction = true;//�S�����I��
                AxeAnim = GameObject.Find("Axe").GetComponent<AxeAnim>();
                AxeAnim.IsChop(isChop);
            animator.SetBool("chop", isChop);
        }
        //���ӂ蒆�Ȃ�N�[���^�C���^�C�}�[�I��
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
        //�S�����Ԃ��߂�����S������
        if (timer > moveRestrictionTime)
        {
            moveRestriction = false;
        }
    }
}
