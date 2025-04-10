using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ToolDirection : MonoBehaviour
{
    PlayerDirection playerDirection;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerDirection = GameObject.Find("Player").GetComponent<PlayerDirection>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (playerDirection.playerDirection)
        {
            //ÉcÅ[ÉãÇ∆çUåÇÇÃìñÇΩÇËîªíËÇÃà íuÇ∆å¸Ç´ÇÃí≤êÆ

            case PlayerDirection.Direction.Up:
                animator.SetFloat("x",0);
                animator.SetFloat("y", 1);

                break;
            case PlayerDirection.Direction.UpRight:
                animator.SetFloat("x", 1);
                animator.SetFloat("y", 1);

                break;
            case PlayerDirection.Direction.Right:
                animator.SetFloat("x", 1);
                animator.SetFloat("y", 0);

                break;
            case PlayerDirection.Direction.DownRight:

                animator.SetFloat("x", 1);
                animator.SetFloat("y", -1);
                break;
            case PlayerDirection.Direction.Down:
                animator.SetFloat("x", 0);
                animator.SetFloat("y", -1);

                break;
            case PlayerDirection.Direction.DownLeft:
                animator.SetFloat("x", -1);
                animator.SetFloat("y", -1);

                break;
            case PlayerDirection.Direction.Left:
                animator.SetFloat("x", -1);
                animator.SetFloat("y", 0);

                break;
            case PlayerDirection.Direction.UpLeft:
                animator.SetFloat("x", -1);
                animator.SetFloat("y", 1);
                break;
        }

       
    }
}
