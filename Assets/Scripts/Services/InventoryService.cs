using GameWorkstore.Patterns;

namespace RogueStore
{
    public class InventoryService : IService
    {
        public Signal<int> OnCoinAmountUpdated = new Signal<int>();
        private int _coinAmount = 1000;

        public override void Postprocess()
        {
        }

        public override void Preprocess()
        {
        }

        internal void UpdateCoinCount(int value)
        {
            _coinAmount += value;
            OnCoinAmountUpdated.Invoke(_coinAmount);
        }

        internal bool SpendCoins(int cost)
        {
            if (_coinAmount >= cost)
            {
                _coinAmount -= cost;
                OnCoinAmountUpdated.Invoke(_coinAmount);
                return true;
            }
            return false;
        }
    }
}