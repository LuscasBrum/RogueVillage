using GameWorkstore.Patterns;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RogueStore
{
    public class UiStore : MonoBehaviour
    {
        private GameService _gameService;
        private StoreService _storeService;

        [SerializeField] private Button _bntClose;
        [SerializeField] private UiSingleItemHolderPoolableList _storeItem;

        private void Awake()
        {
            _gameService = ServiceProvider.GetService<GameService>();
            _storeService = ServiceProvider.GetService<StoreService>();
            _bntClose.onClick.AddListener(CloseStore);
        }

        private void OnEnable()
        {
            _storeItem.Template.gameObject.SetActive(false);
            ItemType[] types = (ItemType[])Enum.GetValues(typeof(ItemType));
            _storeItem.SetActiveCount(types.Length);

            for (int i = 0; i < types.Length; i++)
            {
                _storeItem[i].Setup(GetItemsOfType(types[i]), i);
            }
        }

        private Item[] GetItemsOfType(ItemType type)
        {
            var data = _storeService.GetStoreData();

            List<Item> items = new List<Item>();

            for (int i = 0; i < data.items.Length; i++)
            {
                if (data.items[i].Type != type) continue;
                items.Add(data.items[i]);
            }

            return items.ToArray();
        }

        private void CloseStore()
        {
            _gameService.CallShopping();
            _storeService.GetCurrentClothes();
        }
    }
}
