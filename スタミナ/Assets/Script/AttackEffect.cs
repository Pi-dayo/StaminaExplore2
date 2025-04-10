using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    Attack attack;
    [SerializeField]GameObject attackEffect;
    bool firstAttack=false;

    void Start()
    {
        attack=GameObject.Find("Player").GetComponent<Attack>();
    }

    void Update()
    {
        //攻撃エフェクトを一回だけ出す
        if (attack.IsAttack && !firstAttack)
        {
            Instantiate(attackEffect, transform);
            firstAttack = true;
        }
        else if (!attack.IsAttack)
        {
            firstAttack = false;
        }
    }
}
