using GameWorkstore.Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RogueStore
{
    public class UiGameplay : MonoBehaviour
    {
        private InventoryService _inventoryService;
        [SerializeField] private TextMeshProUGUI _txtCoinAmount;

        private void Awake()
        {
            _inventoryService = ServiceProvider.GetService<InventoryService>();
            _inventoryService.OnCoinAmountUpdated.Register(UpdateCoinCount);
        }

        private void UpdateCoinCount(int value)
        {
            _txtCoinAmount.text = value.ToString();
        }
    }
}
