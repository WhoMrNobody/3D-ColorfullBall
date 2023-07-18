using ColorFullBall.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ColorFullBall.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Image _whiteImage;
        [SerializeField] GameObject _settingOpen, _settingClose, _layoutBackground;
        [SerializeField] GameObject _muteOnButton, _muteOffButton;
        [SerializeField] GameObject _vibrationOnButton, _vibrationOffButton;
        [SerializeField] GameObject _iapButton;
        [SerializeField] GameObject _informationButton, _infoGameObject;
        [SerializeField] Animator _layoutAnimator;
        [SerializeField] GameObject _shopBtn, _noAdsBtn;
        [SerializeField] GameObject _tapToText, _tapHand;
        [SerializeField] GameObject _restartBtn;


        int _alphaValue = 0;

        private void Start()
        {
            if (!PlayerPrefs.HasKey("Sound"))
            {
                PlayerPrefs.SetInt("Sound", 1);
            }

            if (!PlayerPrefs.HasKey("Vibration"))
            {
                PlayerPrefs.SetInt("Vibration", 1);
            }

        }

        public void DisableAllUIElements()
        {
            _settingOpen.SetActive(false);
            _settingClose.SetActive(false);
            _muteOnButton.SetActive(false);
            _muteOffButton.SetActive(false);
            _vibrationOnButton.SetActive(false);
            _vibrationOffButton.SetActive(false);
            _iapButton.SetActive(false);
            _informationButton.SetActive(false);
            _shopBtn.SetActive(false);
            _tapToText.SetActive(false);
            _noAdsBtn.SetActive(false);
            _tapHand.SetActive(false);
            _tapHand.SetActive(false);
        }

        public void RestartBtnActive()
        {
            _restartBtn.SetActive(true);
        }

        public void RestartBtn()
        {
            GameManager.Instance.GameStatusValue = GameManager.GameStatus.None;
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public IEnumerator FlashDeathEffect()
        {   
            _whiteImage.gameObject.SetActive(true);

            while(_alphaValue == 0)
            {
                yield return new WaitForSeconds(0.01f);
                _whiteImage.color += new Color(0f, 0f, 0f, 0.1f);

                if(_whiteImage.color == new Color(_whiteImage.color.r, _whiteImage.color.g, _whiteImage.color.b, 1f))
                {
                    _alphaValue = 1;
                }
            }

            while(_alphaValue == 1)
            {
                yield return new WaitForSeconds(0.01f);
                _whiteImage.color -= new Color(0f, 0f, 0f, 0.1f);

                if(_whiteImage.color == new Color(_whiteImage.color.r, _whiteImage.color.g, _whiteImage.color.b, 0f))
                {
                    _alphaValue = 0;
                }
            }

        }


        public void OpenSettings()
        {
            _layoutAnimator.SetTrigger("SlideDown");
            _settingOpen.SetActive(false);
            _settingClose.SetActive(true);

            if(PlayerPrefs.GetInt("Sound") == 1)
            {
                _muteOffButton.SetActive(false);
                _muteOnButton.SetActive(true);
                AudioListener.volume = 1;
            }
            else
            {
                _muteOffButton.SetActive(true);
                _muteOnButton.SetActive(false);
                AudioListener.volume = 0;
            }

            if(PlayerPrefs.GetInt("Vibration") == 1)
            {
                _muteOnButton.SetActive(true);
                _muteOffButton.SetActive(false);
            }
            else
            {
                _muteOnButton.SetActive(false);
                _muteOffButton.SetActive(true);
            }
           
        }

        public void CloseSettings()
        {
            _layoutAnimator.SetTrigger("SlideUp");
            _settingClose.SetActive(false);
            _settingOpen.SetActive(true);
        }

        public void MuteOnButton()
        {
            _muteOnButton.SetActive(false);
            _muteOffButton.SetActive(true);
            AudioListener.volume = 0f;
            PlayerPrefs.SetInt("Sound", 0);
        }

        public void MuteOffButton()
        {
            _muteOffButton.SetActive(false);
            _muteOnButton.SetActive(true);
            AudioListener.volume = 1f;
            PlayerPrefs.SetInt("Sound", 1);
        }

        public void VibrationOnButton()
        {
            _vibrationOnButton.SetActive(false);
            _vibrationOffButton.SetActive(true);
            PlayerPrefs.SetInt("Vibration", 0);
        }

        public void VibrationOffButton()
        {
            _vibrationOffButton.SetActive(false);
            _vibrationOnButton.SetActive(true);
            PlayerPrefs.SetInt("Vibration", 1);
        }

    }
}

