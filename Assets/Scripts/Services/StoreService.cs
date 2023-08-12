using GameWorkstore.Patterns;
using System.Linq;
using UnityEngine;

namespace RogueStore
{
    public class StoreService : IService
    {
        private ShopDatabase _shopDatabase;
        private SaveService _saveService;

        public Signal<int[]> OnChangeClothesView = new Signal<int[]>();

        private int[] _currentIds;

        public override void Postprocess()
        {
        }

        public override void Preprocess()
        {
            _saveService = ServiceProvider.GetService<SaveService>();
            _shopDatabase = Resources.Load<ShopDatabase>("ShopDatabase");
            _currentIds = _saveService.PlayerData.CurrentClothes.ToArray();
        }

        internal Item GetItem(int id)
        {
            return _shopDatabase.items.FirstOrDefault(item => item.ID == id);
        }

        internal ShopDatabase GetStoreData()
        {
            return _shopDatabase;
        }

        internal void ChangeClothes(int[] clothes)
        {
            _currentIds = clothes;
            OnChangeClothesView.Invoke(clothes);
        }

        internal void SetInitialClothes()
        {
            OnChangeClothesView.Invoke(_currentIds);
        }

        internal void ChangeUniqueClothe(int index, int value)
        {
            _currentIds[index] = value;
            OnChangeClothesView.Invoke(_currentIds);
        }

        internal bool CanPurchase(int price)
        {
            return _saveService.PlayerData.Coins > price ? true : false;
        }

        internal void GetCurrentClothes()
        {
           OnChangeClothesView.Invoke(_saveService.PlayerData.CurrentClothes.ToArray());
        }

        internal void Purchase(Item item)
        {
            _saveService.SpendCoins(item.Cost);
            _saveService.SetIdUnlocked(item.ID);
        }
    }
}
