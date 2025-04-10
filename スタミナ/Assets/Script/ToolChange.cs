using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolChange : MonoBehaviour
{
    [SerializeField] List<GameObject> tools;//�c�[�����X�g
    int toolNum;//���݂̎莝���c�[��
    public enum ToolState//�c�[���̎��
    {
        None,Melee,PickAxe,Axe
    }
    ToolState toolState = ToolState.None;//���݂̎莝���c�[���̏��

    private void Start()
    {
        toolNum = 0;//�莝�����Ȃ��Ŏn�߂�
        ToolChanger();//�c�[���ύX
    }
    void Update()
    {
        toolNum += (int)Input.mouseScrollDelta.y;//�}�E�X�z�C�[���Ńc�[���ύX
        //�c�[���̔ԍ������[�v����悤��
        if (toolNum < 0)
        {
            toolNum=Enum.GetValues(typeof(ToolState)).Length-1;
        }
        else if (toolNum > Enum.GetValues(typeof(ToolState)).Length-1)
        {
            toolNum = 0;
        }
        ToolChanger();//�c�[���ύX
    }
    void ToolChanger()
    {
        switch (toolNum)//�c�[���ԍ��Ŏ莝����ύX�ł���
        {
            case 0:
                for (int i = 0; i < tools.Count; i++)
                {
                    tools[i].SetActive(false);
                }
                break;
            case 1:
                for (int i = 0; i < tools.Count; i++)
                {
                    if (i == 0)
                    {
                        tools[i].SetActive(true);
                    }
                    else
                    {
                        tools[i].SetActive(false);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < tools.Count; i++)
                {
                    if (i == 1)
                    {
                        tools[i].SetActive(true);
                    }
                    else
                    {
                        tools[i].SetActive(false);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < tools.Count; i++)
                {
                    if (i == 2)
                    {
                        tools[i].SetActive(true);
                    }
                    else
                    {
                        tools[i].SetActive(false);
                    }
                }
                break;
        }
    }
}
