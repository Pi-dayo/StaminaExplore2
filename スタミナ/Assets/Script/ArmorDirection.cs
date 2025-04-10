using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorDirection : PlayerDirection
{
    [SerializeField] PlayerArmor playerArmorParts;//�p�[�c�A�Z�b�g
    SpriteRenderer spriteRenderer;//�p�[�c�̉摜
    PlayerDirection pD;//�v���C���[�̕���
    static StoryManager story;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pD = GameObject.Find("Player").GetComponent<PlayerDirection>();
        spriteRenderer.sprite = playerArmorParts.sprite[4];
    }

    // Update is called once per frame
    void Update()
    {
        //if (!StoryManager.story.IsStory)
        //{
            PartsDirection();
        //}
    }

    //�p�[�c�̑S�����̉摜�؂�ւ�
    void PartsDirection()
    {
            switch (pD.playerDirection)
            {
                case PlayerDirection.Direction.Up:
                    spriteRenderer.sprite = playerArmorParts.sprite[0];
                    break;
                case PlayerDirection.Direction.UpRight:
                    spriteRenderer.sprite = playerArmorParts.sprite[1];
                    break;
                case PlayerDirection.Direction.Right:
                    spriteRenderer.sprite = playerArmorParts.sprite[2];
                    break;
                case PlayerDirection.Direction.DownRight:
                    spriteRenderer.sprite = playerArmorParts.sprite[3];
                    break;
                case PlayerDirection.Direction.Down:
                    spriteRenderer.sprite = playerArmorParts.sprite[4];
                    break;
                case PlayerDirection.Direction.DownLeft:
                    spriteRenderer.sprite = playerArmorParts.sprite[5];
                    break;
                case PlayerDirection.Direction.Left:
                    spriteRenderer.sprite = playerArmorParts.sprite[6];
                    break;
                case PlayerDirection.Direction.UpLeft:
                    spriteRenderer.sprite = playerArmorParts.sprite[7];
                    break;
            }
        }

    }
