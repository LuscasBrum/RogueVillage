using GameWorkstore.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RogueStore
{
    public class UiItemShopHolder : MonoBehaviour
    {
        [SerializeField] Button _btnRight;
        [SerializeField] Button _btnLeft;
        [SerializeField] Button _btnBuy;

        [SerializeField] TextMeshProUGUI _txtPrice;
        [SerializeField] TextMeshProUGUI _txtName;

        private Item _item;
        private Item[] _items;
        private ItemType _type;

        private void Awake()
        {
            _btnRight.onClick.AddListener(Right);
            _btnLeft.onClick.AddListener(Left);
        }

        public void Setup(ItemType type, Item[] items)
        {
            _items = items;
            _type = type;
        }

        private void Right()
        {

        }

        private void Left()
        {

        }

        private void Buy()
        {

        }
    }

    [Serializable]
    public class UiSingleItemHolderPoolableList : TemplatePool<UiItemShopHolder> { }
}
