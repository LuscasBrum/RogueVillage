using GameWorkstore.Patterns;
using GameWorkstore.ProtocolUI;
using UnityEngine;

namespace RogueStore
{
    public class MerchantBehavior : Interactable
    {
        private UIStateService _uIStateService;
        [SerializeField] private UIStateScriptable _storeState;

        private void Awake()
        {
            _uIStateService = ServiceProvider.GetService<UIStateService>();
        }

        public override void Interact()
        {
            _uIStateService.SetState(_storeState);
        }
    }
}
