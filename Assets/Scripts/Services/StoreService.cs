using GameWorkstore.Patterns;
using UnityEngine;

namespace RogueStore
{
    public class StoreService : IService
    {
        private ShopDatabase _shopDatabase;

        public override void Postprocess()
        {
        }

        public override void Preprocess()
        {
            _shopDatabase = Resources.Load<ShopDatabase>("ShopDatabase");
        }

        internal ShopDatabase GetStoreData()
        {
            return _shopDatabase;
        }

    }
}
