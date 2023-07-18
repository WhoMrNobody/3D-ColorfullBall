using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorFullBall.Managers
{
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance;

        static string Coin_Key="Coin";
        public string COIN_KEY => Coin_Key;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(Instance);
            }

        }

        public void CoinCalculartor(int coinAmount)
        {
            if (PlayerPrefs.HasKey(COIN_KEY))
            {   
                int oldCoinAmount = PlayerPrefs.GetInt(COIN_KEY);
                PlayerPrefs.SetInt(COIN_KEY, oldCoinAmount + coinAmount);
            }
            else
            {
                PlayerPrefs.SetInt(COIN_KEY, 0);
            }
        }

    }
}

