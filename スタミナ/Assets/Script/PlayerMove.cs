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
    private LayerMask solidLayers;//通過不能レイヤーマスク
    private string[] solidLayerName = {"Wall","NPC","Enemy"};//ここに通過不能のレイヤーを追加していく
    Animator animator;
    int ratio=2;//マス単位の調整
     StoryManager story;//ストーリ中の制御

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
        if (!isMoving && MoveRestriction())//移動中は入力を受け付けない
        {
            Boolean diagonalflg = false;
            Vector2 basePos = playerInput;

            playerInput.x = UnityEngine.Input.GetAxisRaw("Horizontal") / ratio;//横方向入力
            playerInput.y = UnityEngine.Input.GetAxisRaw("Vertical") / ratio;//縦方向入力
            if (playerInput != Vector2.zero)//入力があったら移動
            {
                Vector2 targetPos = transform.position;//移動先の初期化
                Vector2 diagX = targetPos;
                Vector2 diagY = targetPos;
                targetPos += playerInput;//移動先

                //x,y　両方に値がある場合は斜めとして判断
                if (playerInput.x != 0 && playerInput.y != 0)
                {
                    diagonalflg = true; //斜めフラグ
                    diagX.x += playerInput.x; //斜め移動の通過点(X)を設定
                    diagY.y += playerInput.y; //斜め移動の通過点(Y)を設定
                }
                //移動先に障害物がなかったら
                //斜め移動の場合、通過点の障害物判定も合わせて行う
                if ((diagonalflg && (IsWalkable(diagX) && IsWalkable(diagY)) && IsWalkable(targetPos)) || (!diagonalflg && IsWalkable(targetPos)))
                {
                    StartCoroutine(Move(targetPos));//移動
                }
            }
        }
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;//移動中にして入力を受けないように
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //マスを徐々に移動する処理
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;//プレイヤーの位置を調整
        isMoving = false;//移動中判定をオフ
    }

    bool IsWalkable(Vector2 targetpos)
    {
        return !Physics2D.OverlapCircle(targetpos, 0.2f, solidLayers);//移動先に障害物があるかどうか
    }

    //アクション中の拘束
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
