using GameWorkstore.Patterns;
using System;
using System.Reflection;
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

        private StoreService _storeService;
        private SaveService _saveService;

        private Item[] _items;
        private int _index;
        private int _indexType;

        private void Awake()
        {
            _storeService = ServiceProvider.GetService<StoreService>();
            _saveService = ServiceProvider.GetService<SaveService>();

            _btnRight.onClick.AddListener(Right);
            _btnLeft.onClick.AddListener(Left);
        }

        public void Setup(Item[] items, int index)
        {
            _indexType = index;
            _items = items;

            for (int i = 0; i < _items.Length; i++)
            {
                var item = _items[i];
                if(item.ID == _saveService.PlayerData.CurrentClothes[_indexType])
                {
                    index = i;
                    _txtName.text = _items[_index].name;
                    _txtPrice.text = _items[_index].Cost.ToString();
                    UpdateScreen();
                    return;
                }
            }
        }

        private void Right()
        {
            _index++;

            if (_index >= _items.Length)
            {
                _index = 0; 
            }
            _txtName.text = _items[_index].name;
            _txtPrice.text = _items[_index].Cost.ToString();
            _storeService.ChangeUniqueClothe(_indexType, _items[_index].ID);
            UpdateScreen();
        }

        private void Left()
        {
            _index--;

            if (_index < 0)
            {
                _index = _items.Length - 1; 
            }

            _txtName.text = _items[_index].name;
            _txtPrice.text = _items[_index].Cost.ToString();
            _storeService.ChangeUniqueClothe(_indexType, _items[_index].ID);
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            var txtDescription = _btnBuy.GetComponentInChildren<TextMeshProUGUI>();
            var img = _btnBuy.GetComponent<Image>();

            var item = _items[_index];

            if (_saveService.IsItemPurchased(_items[_index].ID))
            {
                _btnBuy.onClick.RemoveAllListeners();
                _btnBuy.onClick.AddListener(Save);
                txtDescription.text = "Save";
                img.color = Color.blue;
            }
            else
            {
                txtDescription.text = "Buy";
                img.color = Color.green;
                _btnBuy.onClick.RemoveAllListeners();
                if (_storeService.CanPurchase(item.Cost))
                {
                    _btnBuy.onClick.AddListener(Buy);
                }
            }
        }

        private void Buy()
        {
            _storeService.Purchase(_items[_index]);
            UpdateScreen();
        }

        private void Save()
        {
            _saveService.SetItem(_indexType, _items[_index].ID);
        }
    }

    [Serializable]
    public class UiSingleItemHolderPoolableList : TemplatePool<UiItemShopHolder> { }
}
