using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    Camera cam;//メインカメラ
    Vector2 mousePos;//マウスの位置
    Vector2 direction;//方向
    public Direction playerDirection;//現在見ている方向
    Attack attack;
    Mining mining;
    Chop chop;
    Animator playerAnimator;
    int directionX;
    int directionY;
    // Start is called before the first frame update
    //制御する向きの列挙
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
            Debug.Log("オブジェクトがありません");
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
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);//マウスも位置をワールド座標からスクリーン座標に変換
            direction = (mousePos - (Vector2)transform.position);//プレイヤーとマウスの位置から方向を計算
            int angle = (int)(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;//角度の計算　　+90は実験の名残
                                                                                          //向きの条件分け
            if (angle > 158 && angle < 203)
            {
                playerDirection = Direction.Up;//上
                directionX = 0;
                directionY = 1;
            }
            else if (angle > 113 && angle < 158)
            {
                playerDirection = Direction.UpRight;//右上
                directionX = 1;
                directionY = 1;
            }
            else if (angle > 68 && angle < 113)
            {
                playerDirection = Direction.Right;//右
                directionX = 1;
                directionY = 0;
            }
            else if (angle > 23 && angle < 68)
            {
                playerDirection = Direction.DownRight;//右下
                directionX = 1;
                directionY = -1;
            }
            else if (angle < 23 && angle > -23)
            {
                playerDirection = Direction.Down;//下
                directionX = 0;
                directionY = -1;
            }
            else if (angle > -68 && angle < -23)
            {
                playerDirection = Direction.DownLeft;//左下
                directionX = -1;
                directionY = -1;
            }
            else if (angle > 258 || angle < -68)
            {
                playerDirection = Direction.Left;//左
                directionX = -1;
                directionY = 0;
            }
            else if (angle > 203 && angle < 258)
            {
                playerDirection = Direction.UpLeft;//左上
                directionX = -1;
                directionY = 1;
            }
            playerAnimator.SetFloat("directionX", directionX);
            playerAnimator.SetFloat("directionY", directionY);
        }
    }
    //アクション拘束
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
