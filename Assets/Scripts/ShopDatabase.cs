using UnityEngine;

namespace RogueStore
{
    [CreateAssetMenu(fileName = "Database", menuName = "RogueStore/Database")]
    public class ShopDatabase : ScriptableObject
    {
        Item[] items;
    }
}
