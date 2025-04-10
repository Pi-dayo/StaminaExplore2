using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bag : MonoBehaviour
{
    [SerializeField]RectTransform bag;
    Vector2 bagSize;
    private void Start()
    {
        bagSize=bag.sizeDelta;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (bag.sizeDelta.x < bagSize.x+10 && bag.sizeDelta.y < bagSize.y+10)
            {
                bag.sizeDelta += new Vector2(0.05f, 0.05f);
            }
        }
        if (bag.sizeDelta.x > bagSize.x || bag.sizeDelta.y > bagSize.y)
        {
            bag.sizeDelta -= new Vector2(0.01f, 0.01f);
        }
        else
        {
            bag.sizeDelta = bagSize;
        }
    }
    }

