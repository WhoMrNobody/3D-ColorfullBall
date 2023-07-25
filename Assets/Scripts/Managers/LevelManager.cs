using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorFullBall.Managers
{
    public class LevelManager : MonoBehaviour
    {   
        public static LevelManager Instance;

        static string Level_Key = "LevelIndex";

        public string LEVEL_KEY => Level_Key;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        void Start()
        {
            if (PlayerPrefs.HasKey(LEVEL_KEY))
            {
                PlayerPrefs.SetInt(LEVEL_KEY, 1);
            }

            LevelControl();
        }

        public void LevelControl()
        {
            int level = PlayerPrefs.GetInt(LEVEL_KEY);
            SceneManager.LoadSceneAsync(level);
        }
       
    }
}

