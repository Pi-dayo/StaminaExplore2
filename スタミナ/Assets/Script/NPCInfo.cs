using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (menuName ="NPC")]
public class NPCInfo : ScriptableObject
{
    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] List<Sprite> npcDirection;

    public List<Sprite> NpcDirection { get => npcDirection; }
}
