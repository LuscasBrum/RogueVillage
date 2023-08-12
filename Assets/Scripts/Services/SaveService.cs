using UnityEngine;
using GameWorkstore.Patterns;
using Google.Protobuf;
using System;

namespace RogueStore
{
    public class SaveService : IService
    {
        private const string _playerKey = "PLAYER_KEY";
        public PlayerGameData PlayerData = null;
        public Signal<int> OnCoinAmountUpdated = new Signal<int>();
        public Signal<int> OnProductUnlocked = new Signal<int>();
        public override void Preprocess()
        {
            Load();
        }

        public void Load()
        {
            var data = PlayerPrefs.GetString(_playerKey, string.Empty);
            if (string.IsNullOrEmpty(data))
            {
                PlayerData = GetDefaultSave();
                return;
            }
            try
            {
                byte[] bytes = Convert.FromBase64String(data);
                PlayerData = PlayerGameData.Parser.ParseFrom(bytes);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error while loading save: {e.Message}");
                PlayerData = GetDefaultSave();
            }
        }
        private PlayerGameData GetDefaultSave()
        {
            PlayerGameData playerGameData = new PlayerGameData();
            playerGameData.Coins = 1000;

            int[] defaultClothes = new int[]
            {
                1444281160,
                -1567196663,
                629567936,
                1767392545,
                235949063,
                1734472721,
                1299919368,
                -478008819,
                1368096029
            };

            for (int i = 0; i < defaultClothes.Length; i++)
            {
                playerGameData.CurrentClothes.Add(defaultClothes[i]);
            }

            for (int i = 0; i < defaultClothes.Length; i++)
            {
                playerGameData.UnlockedIds.Add(defaultClothes[i]);
            }

            return playerGameData;
        }

        public void Save()
        {
            string sbase64 = Convert.ToBase64String(PlayerData.ToByteArray());
            PlayerPrefs.SetString(_playerKey, sbase64);
        }

        public override void Postprocess()
        {
        }


        internal void UpdateCoinCount(int value)
        {
            PlayerData.Coins += value;
            OnCoinAmountUpdated.Invoke(PlayerData.Coins);
        }

        internal bool SpendCoins(int cost)
        {
            if (PlayerData.Coins >= cost)
            {
                PlayerData.Coins -= cost;
                OnCoinAmountUpdated.Invoke(PlayerData.Coins);
                return true;
            }
            return false;
        }

        public void SetItem(int index, int value)
        {
            PlayerData.CurrentClothes[index] = value;
            Save();
        }

        public void SetIdUnlocked(int id)
        {
            if (PlayerData.UnlockedIds.Contains(id)) return;
            PlayerData.UnlockedIds.Add(id);
        }

        internal bool IsItemPurchased(int id)
        {
            return PlayerData.UnlockedIds.Contains(id);
        }
    }
}