using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Object")]
public class ObjectInfo : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] float hp;
    [SerializeField] List<Sprite> damageStateSprites;
    [SerializeField] AppropriateTools apTools;

    public Sprite Sprite { get => sprite;}
    public float Hp { get => hp;}
    public List<Sprite> DamageStateSprites { get => damageStateSprites; }
    public AppropriateTools ApTools { get => apTools; }

    public enum AppropriateTools
    {
        None,Sword,PickAxe,Axe
    }

}
