using GameWorkstore.Patterns;
using GameWorkstore.ProtocolUI;
using UnityEngine;

namespace RogueStore
{
    public class MerchantBehavior : Interactable
    {
        private UIStateService _uIStateService;
        private GameService _gameService;

        [SerializeField] private UIStateScriptable _storeState;

        private void Awake()
        {
            _uIStateService = ServiceProvider.GetService<UIStateService>();
            _gameService = ServiceProvider.GetService<GameService>();
        }

        public override void Interact()
        {
            _uIStateService.SetState(_storeState);
            _gameService.OpenStore();
        }
    }
}
