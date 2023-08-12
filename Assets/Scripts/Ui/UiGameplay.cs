using GameWorkstore.Patterns;
using TMPro;
using UnityEngine;

namespace RogueStore
{
    public class UiGameplay : MonoBehaviour
    {
        private SaveService _saveService;
        [SerializeField] private TextMeshProUGUI _txtCoinAmount;

        private void Awake()
        {
            _saveService = ServiceProvider.GetService<SaveService>();
            _saveService.OnCoinAmountUpdated.Register(UpdateCoinCount);
        }

        private void UpdateCoinCount(int value)
        {
            _txtCoinAmount.text = value.ToString();
        }
    }
}
