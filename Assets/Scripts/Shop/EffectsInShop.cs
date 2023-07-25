using ColorFullBall.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorFullBall.UI
{
    public class EffectsInShop : MonoBehaviour
    {
        [SerializeField] Button _effect1Btn, _effect2Btn, _effect3Btn;
        [SerializeField] GameObject _trailEffect1, _trailEffect2, _trailEffect3;
        [SerializeField] Sprite _activeEffectImg, _deactiveEffectImg;

        int coin;

        void Awake()
        {
            if (!PlayerPrefs.HasKey("ActivatedEffect"))
            {
                PlayerPrefs.SetInt("ActivatedEffect", 0);
            }

        }
        void Start()
        {
           coin = PlayerPrefs.GetInt(CoinManager.Instance.COIN_KEY);

            if (PlayerPrefs.GetInt("ActivatedEffect") == 2)
            {
                EffectActivationID(2);
            }
            else if (PlayerPrefs.GetInt("ActivatedEffect") == 3)
            {
                EffectActivationID(3);
            }

            Debug.Log(PlayerPrefs.GetInt("ActivatedEffect"));
        }
        public void EffectActivationID(int index)
        {
            switch (index)
            {
                case 1:

                    if (PlayerPrefs.GetInt("ActivatedEffect") == 0){

                        _effect1Btn.image.sprite = _activeEffectImg;
                        _trailEffect1.SetActive(true);

                        _effect2Btn.image.sprite = _deactiveEffectImg;
                        _effect3Btn.image.sprite = _deactiveEffectImg;
                        _trailEffect2.SetActive(false);
                        _trailEffect3.SetActive(false);
                    }

                    break;
                    
                case 2:

                    if(coin <= 1000)
                    {
                        return;
                    }
                    else
                    {
                        PlayerPrefs.SetInt("ActivatedEffect", 2);
                        _effect2Btn.image.sprite = _activeEffectImg;
                        _trailEffect2.SetActive(true);

                        _effect1Btn.image.sprite = _deactiveEffectImg;
                        _effect3Btn.image.sprite = _deactiveEffectImg;
                        _trailEffect1.SetActive(false);
                        _trailEffect3.SetActive(false);
                    }

                    break;

                case 3:

                    if(coin <= 2000)
                    {
                        return;
                    }
                    else
                    {
                        PlayerPrefs.SetInt("ActivatedEffect", 3);
                        _effect3Btn.image.sprite = _activeEffectImg;
                        _trailEffect3.SetActive(true);

                        _effect1Btn.image.sprite = _deactiveEffectImg;
                        _effect2Btn.image.sprite = _deactiveEffectImg;
                        _trailEffect1.SetActive(false);
                        _trailEffect2.SetActive(false);
                    }

                    break; 
                
                default:

                    _effect1Btn.image.sprite = _activeEffectImg;
                    _trailEffect1.SetActive(true);

                    _effect2Btn.image.sprite = _deactiveEffectImg;
                    _effect3Btn.image.sprite = _deactiveEffectImg;
                    _trailEffect2.SetActive(false);
                    _trailEffect3.SetActive(false);

                    break;
            }
        }

    }

}
