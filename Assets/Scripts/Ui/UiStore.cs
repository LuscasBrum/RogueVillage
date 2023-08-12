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
    private RawImage _characterRenderer;

    private Vector2 _characterRendererOffSet;
    [SerializeField] private Vector2 _characterRendererStoreOffSet;
    [SerializeField] private Vector2 _characterRendererStoreScale;

    private void Awake()
    {
        _gameService = ServiceProvider.GetService<GameService>();
        _bntClose.onClick.AddListener(CloseStore);
        _characterRenderer = GameObject.FindObjectOfType<RawImage>();
        _characterRendererOffSet = _characterRenderer.rectTransform.localPosition;
    }

    private void OnEnable()
    {
        SetCharacterVisualizationStore();
    }

    private void OnDisable()
    {
        SetCharacterVisualizationGameplay();
    }

    private void SetCharacterVisualizationStore()
    {
        if (_characterRenderer == null) return;
        _characterRenderer.rectTransform.localPosition = _characterRendererStoreOffSet;
        _characterRenderer.rectTransform.localScale = _characterRendererStoreScale;
    }

    private void SetCharacterVisualizationGameplay()
    {
        if (_characterRenderer == null) return;
        _characterRenderer.rectTransform.localPosition = _characterRendererOffSet;
        _characterRenderer.rectTransform.localScale = new Vector2(1, 1);
    }

    private void CloseStore()
    {
        _gameService.OpenStore();
    }

}
