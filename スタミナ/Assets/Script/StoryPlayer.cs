using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPlayer : MonoBehaviour
{
    [SerializeField] List<StoryPlayerParts> parts;
    public void PartsUp()
    {
        foreach (var part in parts)
        {
            part.Up();
        }
    }
    public void PartsUpRight()
    {
        foreach (var part in parts)
        {
            part.UpRight();
        }
    }
    public void PartsRight()
    {
        foreach (var part in parts)
        {
            part.Right();
        }
    }
    public void PartsDownRight()
    {
        foreach (var part in parts)
        {
            part.DownRight();
        }
    }
    public void PartsDown()
    {
        foreach (var part in parts)
        {
            part.Down();
        }
    }
    public void PartsDownLeft()
    {
        foreach (var part in parts)
        {
            part.DownLeft();
        }
    }
    public void PartsLeft()
    {
        foreach (var part in parts)
        {
            part.Left();
        }
    }
    public void PartsUpLeft()
    {
        foreach (var part in parts)
        {
            part.UpLeft();
        }
    }
}
