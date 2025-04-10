using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class MonsTest : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    Vector2 diff;
    float rad;
    float angle;
    float timer;
    float dodgeTimer;
    float dodgeTime = 1;
    float biteTimer;
    float biteTime = 1;
    float maxStm = 100;
    float stmDiff;
    float stm;
    float stmRecovery;

    [SerializeField] float moveTime;
    [SerializeField] int moveChance;
    [SerializeField] float eyesight;
    [SerializeField] LayerMask playerLayerMask;
    [SerializeField] GameObject BiteCollision;
    bool isMove;
    bool isDodge;
    bool isBite;
    bool isRest;
    int directionX;
    int directionY;
    int dirResX;
    int dirResY;
    float randomX;
    float randomY;
    Animator animator;
    [SerializeField] float speed;
    Vector2 preVec;
    static System.Random random;
    Rigidbody2D rb;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        random = new System.Random();
        stm=maxStm;
    }

    // Update is called once per frame
    void Update()
    {
        diff = player.transform.position - this.transform.position;
        diff = diff.normalized;
        rad = Mathf.Atan2(diff.y, diff.x);
        angle = rad * Mathf.Rad2Deg + 90;
        timer += Time.deltaTime;

        if (timer > moveTime)
        {
            if (isMove && !IsContact())
            {
                randomX = 0;
                randomY = 0;
                directionX = (int)preVec.x;
                directionY = (int)preVec.y;
                isMove = false;
            }
            else
            {
                int moveC = random.Next(0, moveChance * 2);
                if (IsContact())
                {
                    moveC *= 2;
                }
                if (moveC >= moveChance)
                {
                    if (IsContact())
                    {
                        directionX = Mathf.RoundToInt(diff.x);
                        directionY = Mathf.RoundToInt(diff.y);
                        randomX = diff.x;
                        randomY = diff.y;
                    }
                    else
                    {
                        randomX = random.Next(-1, 2);
                        randomY = random.Next(-1, 2);
                        directionX = (int)randomX;
                        directionY = (int)randomY;
                    }
                }
        
            }
            timer = 0;
        }

        if (Vector2.Distance(transform.position, player.transform.position) < 1.5 && MoveRestriction())
        {
            int action = random.Next(0, 100);
            if (action >= 40)
            {
                if (stm > 30)
                {
                    Bite();
                }
                else
                {
                    Rest();
                }
            }
            else if(action >=10&&action<40)
            {
                if (stm > 20)
                {
                    Dodge();
                }
                else
                {
                    Rest();
                }
            }
            else
            {
                Rest();
            }
                randomX = 0;
            randomY = 0;
            isMove = false;
        }
        if (isBite)
        {
            biteTimer += Time.deltaTime;
            if (biteTimer > biteTime)
            {
                isBite = false;
                biteTimer = 0;
            }
        }
        if (isDodge)
        {
            dodgeTimer += Time.deltaTime;
            if (dodgeTimer > dodgeTime)
            {
                isDodge = false;
                dodgeTimer = 0;
            }
        }


        if (!MoveRestriction())
        {
            if (IsContact())
            {
                if (angle > 158 && angle < 203)
                {
                    directionX = 0;
                    directionY = 1;
                }
                else if (angle > 113 && angle < 158)
                {
                    directionX = 1;
                    directionY = 1;
                }
                else if (angle > 68 && angle < 113)
                {
                    directionX = 1;
                    directionY = 0;

                }
                else if (angle > 23 && angle < 68)
                {
                    directionX = 1;
                    directionY = -1;

                }
                else if (angle < 23 && angle > -23)
                {
                    directionX = 0;
                    directionY = -1;

                }
                else if (angle > -68 && angle < -23)
                {
                    directionX = -1;
                    directionY = -1;

                }
                else if (angle > 258 || angle < -68)
                {
                    directionX = -1;
                    directionY = 0;

                }
                else if (angle > 203 && angle < 258)
                {
                    directionX = -1;
                    directionY = 1;

                }
            }
        }
        if (isRest)
        {
            stm += 30f*Time.deltaTime;
            rb.velocity = Vector2.zero;
            isMove = false;
            isDodge = false;
            isBite = false;
            if (stm > stmRecovery)
            {
                isRest = false;
            }
        }
        if (rb.velocity != Vector2.zero)
        {
            isMove = true;
        }
        if (MoveRestriction())
        {
            if (IsContact())
            {
                rb.velocity = new Vector2(randomX, randomY) * speed*2;
            }
            else
            {
                rb.velocity = new Vector2(randomX, randomY) * speed;
            }

        }


        preVec = new Vector2(directionX, directionY);
        animator.SetBool("dodge", isDodge);
        animator.SetBool("bite", isBite);
        animator.SetBool("run", isMove);
        if (!DirectionRestriction())
        {
            animator.SetFloat("x", directionX);
            animator.SetFloat("y", directionY);
        }
        else
        {
            animator.SetFloat("x", dirResX);
            animator.SetFloat("y", dirResY);
        }

    }
    bool IsContact()
    {
        return Physics2D.Raycast(transform.position, diff, eyesight, playerLayerMask);
    }
    void Bite()
    {
        if (!isBite)
        {
            dirResX = (int)preVec.x;
            dirResY = (int)preVec.y;
            Vector2 objDir=new Vector2(-dirResX,-dirResY);
            GameObject biteC= Instantiate(BiteCollision, transform);
            biteC.transform.rotation = Quaternion.FromToRotation(Vector2.up, objDir);
            biteC.transform.localPosition = new Vector3(dirResX,dirResY);
            stm -= 20;
        }
        isBite = true;
        rb.velocity = Vector3.zero;
    }
    void Dodge()
    {
        if (isDodge == false)
        {
            rb.AddForce(new Vector2(directionX * -1, directionY * -1), ForceMode2D.Impulse);
            stm -= 15;
        }
        isDodge = true;
    }
    bool MoveRestriction()
    {
        if (isDodge || isBite||isRest)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    bool DirectionRestriction()
    {
        if (isBite)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Rest()
    {
    
        if (!isRest)
        {
            stmDiff = maxStm - stm;
            stmRecovery = random.Next(0, (int)stmDiff) + stm;
            if (stmRecovery > maxStm)
            {
                stmRecovery = maxStm;
            }
        }
        isRest = true;
    }

    void Direction(float x,float y)
    {

    }

}
