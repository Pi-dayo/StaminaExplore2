using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    Camera cam;//���C���J����
    Vector2 mousePos;//�}�E�X�̈ʒu
    Vector2 direction;//����
    public Direction playerDirection;//���݌��Ă������
    Attack attack;
    Mining mining;
    Chop chop;
    Animator playerAnimator;
    int directionX;
    int directionY;
    // Start is called before the first frame update
    //���䂷������̗�
    private void Start()
    {
        cam = Camera.main;
        playerAnimator=GameObject.Find("Player").GetComponent<Animator>();
        if (GameObject.Find("Player").GetComponent<Attack>() != null)
        {
            attack = GameObject.Find("Player").GetComponent<Attack>();
            mining= GameObject.Find("Player").GetComponent<Mining>();
            chop = GameObject.Find("Player").GetComponent<Chop>();
        }
        else
        {
            Debug.Log("�I�u�W�F�N�g������܂���");
        }
    }
    public enum Direction
    {
        Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft
    }
    // Update is called once per frame
    void Update()
    {
        if (MoveRestriction())
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);//�}�E�X���ʒu�����[���h���W����X�N���[�����W�ɕϊ�
            direction = (mousePos - (Vector2)transform.position);//�v���C���[�ƃ}�E�X�̈ʒu����������v�Z
            int angle = (int)(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;//�p�x�̌v�Z�@�@+90�͎����̖��c
                                                                                          //�����̏�������
            if (angle > 158 && angle < 203)
            {
                playerDirection = Direction.Up;//��
                directionX = 0;
                directionY = 1;
            }
            else if (angle > 113 && angle < 158)
            {
                playerDirection = Direction.UpRight;//�E��
                directionX = 1;
                directionY = 1;
            }
            else if (angle > 68 && angle < 113)
            {
                playerDirection = Direction.Right;//�E
                directionX = 1;
                directionY = 0;
            }
            else if (angle > 23 && angle < 68)
            {
                playerDirection = Direction.DownRight;//�E��
                directionX = 1;
                directionY = -1;
            }
            else if (angle < 23 && angle > -23)
            {
                playerDirection = Direction.Down;//��
                directionX = 0;
                directionY = -1;
            }
            else if (angle > -68 && angle < -23)
            {
                playerDirection = Direction.DownLeft;//����
                directionX = -1;
                directionY = -1;
            }
            else if (angle > 258 || angle < -68)
            {
                playerDirection = Direction.Left;//��
                directionX = -1;
                directionY = 0;
            }
            else if (angle > 203 && angle < 258)
            {
                playerDirection = Direction.UpLeft;//����
                directionX = -1;
                directionY = 1;
            }
            playerAnimator.SetFloat("directionX", directionX);
            playerAnimator.SetFloat("directionY", directionY);
        }
    }
    //�A�N�V�����S��
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
