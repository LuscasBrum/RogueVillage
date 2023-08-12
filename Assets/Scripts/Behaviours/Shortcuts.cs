using GameWorkstore.Patterns;
using RogueStore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueStore
{
    public class Shortcuts : MonoBehaviour
    {
        private SaveService _saveService;

        private void Awake()
        {
            _saveService = ServiceProvider.GetService<SaveService>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                _saveService.UpdateCoinCount(50);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                _saveService.SpendCoins(50);
            }
        }
    }
}