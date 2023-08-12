using GameWorkstore.Patterns;
using RogueStore;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiStore : MonoBehaviour
{
    private GameService _gameService;
    [SerializeField] private Button _bntClose;

    private void Awake()
    {
        _gameService = ServiceProvider.GetService<GameService>();
        _bntClose.onClick.AddListener(CloseStore);
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void CloseStore()
    {
        _gameService.OpenStore();
    }

}
