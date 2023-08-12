using GameWorkstore.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RogueStore {
    [CreateAssetMenu(fileName = "Item", menuName = "RogueStore/Item")]
    public class Item : ScriptableObject
    {
        public bool IsCustomId = false;
        [ConditionalField("IsCustomId")]
        public Item IdReference;

        [FormerlySerializedAs("type")]
        public ItemType Type;

        [FormerlySerializedAs("price")]
        public int Cost;

        public Sprite Preview;

        public int ID => IsCustomId ? IdReference.ID : Animator.StringToHash(name);
    }

    public enum ItemType 
    {
        Boot,
        ElbowPad,
        Face,
        Hair,
        Belt,
        Pants,
        ShoulderPad,
        Shirt,
        Gloves
    }
}
