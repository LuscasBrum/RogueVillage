using GameWorkstore.Patterns;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiGameplay : MonoBehaviour
{
    private InventoryService _inventoryService;
    private TextMeshProUGUI _txtCoinAmount;

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
