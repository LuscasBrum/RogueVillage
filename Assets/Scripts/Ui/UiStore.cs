using GameWorkstore.Patterns;
using UnityEngine;
using UnityEngine.UI;

namespace RogueStore
{
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
}
