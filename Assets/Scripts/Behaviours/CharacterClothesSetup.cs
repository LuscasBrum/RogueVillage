using GameWorkstore.Patterns;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueStore
{
    public class CharacterClothesSetup : MonoBehaviour
    {
        private StoreService _storeService;
        [SerializeField] SpriteRenderer[] _clothesParts;
        [SerializeField] SpriteRenderer[] _EvenParts;

        private void Awake()
        {
            _storeService = ServiceProvider.GetService<StoreService>();
            _storeService.OnChangeClothesView.Register(SetClothes);
            _storeService.SetInitialClothes();
        }

        private void SetClothes(int[] clothes)
        {
            for (int i = 0; i < _clothesParts.Length; i++)
            {
                var item = _storeService.GetItem(clothes[i]);
                if (item == null) 
                {
                    Debug.LogError("Empty Item!");
                    continue; 
                }

                _clothesParts[i].sprite = item.Preview;

                if (item.IsEven)
                {
                    switch (i)
                    {
                        case 0:
                            _EvenParts[0].sprite = item.PreviewEven;
                            break;
                            case 1:
                            _EvenParts[1].sprite = item.PreviewEven;
                            break;
                        case 5:
                            _EvenParts[2].sprite = item.PreviewEven;
                            break;
                        case 6:
                            _EvenParts[3].sprite = item.PreviewEven;
                            break;
                        case 8:
                            _EvenParts[4].sprite = item.PreviewEven;
                            break;
                    }
                }
            }
        }
    }
}
