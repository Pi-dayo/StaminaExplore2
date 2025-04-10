using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolChange : MonoBehaviour
{
    [SerializeField] List<GameObject> tools;//ツールリスト
    int toolNum;//現在の手持ちツール
    public enum ToolState//ツールの種類
    {
        None,Melee,PickAxe,Axe
    }
    ToolState toolState = ToolState.None;//現在の手持ちツールの状態

    private void Start()
    {
        toolNum = 0;//手持ちをなしで始める
        ToolChanger();//ツール変更
    }
    void Update()
    {
        toolNum += (int)Input.mouseScrollDelta.y;//マウスホイールでツール変更
        //ツールの番号がループするように
        if (toolNum < 0)
        {
            toolNum=Enum.GetValues(typeof(ToolState)).Length-1;
        }
        else if (toolNum > Enum.GetValues(typeof(ToolState)).Length-1)
        {
            toolNum = 0;
        }
        ToolChanger();//ツール変更
    }
    void ToolChanger()
    {
        switch (toolNum)//ツール番号で手持ちを変更できる
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
