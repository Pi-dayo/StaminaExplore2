using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ArmorParts")]
public class PlayerArmor : ScriptableObject
{

        public new string name;
        public List<Sprite> sprite;
        [TextArea]
        public string description;
        public PartsType partType;
        public enum PartsType
        {
            Head, Eyes, Face, Body, RightHand, LeftHand, RightLeg, LeftLeg,
        }
}