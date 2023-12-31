using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorFullBall.Managers.GameManager;

namespace ColorFullBall.Managers
{
    public class GameManager : MonoBehaviour
    {
        [HideInInspector] public static GameManager Instance { get; private set; }
        [HideInInspector] public GameStatus GameStatusValue;
        void Awake()
        {

            if(Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            GameStatusValue = GameStatus.None;
        }
        public enum GameStatus
        {
            Started, Paused, Finished, Failed, NextLevel, None
        }

    }
}

