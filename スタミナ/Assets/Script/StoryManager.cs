using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class StoryManager : MonoBehaviour
{
    public static StoryManager story;
    bool isStory;

    public bool IsStory { get => isStory;}

    // Start is called before the first frame update
    void Start()
    {
        if(story == null)
        {
            story = this;
        }
        else
        {
            Destroy(gameObject);
        }
        isStory = true;
    }

    public void StoryStart()
    {
        isStory=true;
    }
    public void StoryStop()
    {
        isStory=false;
    }
}
