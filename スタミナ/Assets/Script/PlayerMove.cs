using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Attack attack;
    Mining mining;
    Chop chop;
    Vector2 playerInput;
    bool isMoving;
    private LayerMask solidLayers;//�ʉߕs�\���C���[�}�X�N
    private string[] solidLayerName = {"Wall","NPC","Enemy"};//�����ɒʉߕs�\�̃��C���[��ǉ����Ă���
    Animator animator;
    int ratio=2;//�}�X�P�ʂ̒���
     StoryManager story;//�X�g�[�����̐���

    // Start is called before the first frame update
    void Start()
    {
        solidLayers = LayerMask.GetMask(solidLayerName);
        animator = GetComponent<Animator>();
        isMoving = false;
        attack=GameObject.Find("Player").GetComponent<Attack>();
        mining= GameObject.Find("Player").GetComponent<Mining>();
        chop= GameObject.Find("Player").GetComponent<Chop>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!StoryManager.story.IsStory)
        //{
            MoveControl();
        //}
    }
    void MoveControl()
    {
        if (playerInput != Vector2.zero&& MoveRestriction())
        {
            animator.SetBool("walk", true);
            animator.SetBool("attack", false);
            animator.SetFloat("x", playerInput.x* ratio);
            animator.SetFloat("y", playerInput.y* ratio);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        if (!isMoving && MoveRestriction())//�ړ����͓��͂��󂯕t���Ȃ�
        {
            Boolean diagonalflg = false;
            Vector2 basePos = playerInput;

            playerInput.x = UnityEngine.Input.GetAxisRaw("Horizontal") / ratio;//����������
            playerInput.y = UnityEngine.Input.GetAxisRaw("Vertical") / ratio;//�c��������
            if (playerInput != Vector2.zero)//���͂���������ړ�
            {
                Vector2 targetPos = transform.position;//�ړ���̏�����
                Vector2 diagX = targetPos;
                Vector2 diagY = targetPos;
                targetPos += playerInput;//�ړ���

                //x,y�@�����ɒl������ꍇ�͎΂߂Ƃ��Ĕ��f
                if (playerInput.x != 0 && playerInput.y != 0)
                {
                    diagonalflg = true; //�΂߃t���O
                    diagX.x += playerInput.x; //�΂߈ړ��̒ʉߓ_(X)��ݒ�
                    diagY.y += playerInput.y; //�΂߈ړ��̒ʉߓ_(Y)��ݒ�
                }
                //�ړ���ɏ�Q�����Ȃ�������
                //�΂߈ړ��̏ꍇ�A�ʉߓ_�̏�Q����������킹�čs��
                if ((diagonalflg && (IsWalkable(diagX) && IsWalkable(diagY)) && IsWalkable(targetPos)) || (!diagonalflg && IsWalkable(targetPos)))
                {
                    StartCoroutine(Move(targetPos));//�ړ�
                }
            }
        }
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;//�ړ����ɂ��ē��͂��󂯂Ȃ��悤��
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //�}�X�����X�Ɉړ����鏈��
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;//�v���C���[�̈ʒu�𒲐�
        isMoving = false;//�ړ���������I�t
    }

    bool IsWalkable(Vector2 targetpos)
    {
        return !Physics2D.OverlapCircle(targetpos, 0.2f, solidLayers);//�ړ���ɏ�Q�������邩�ǂ���
    }

    //�A�N�V�������̍S��
    bool MoveRestriction()
    {
        if (!attack.MoveRestriction && !mining.MoveRestriction&&!chop.MoveRestriction)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
