using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorFullBall.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Image _whiteImage;
        [SerializeField] GameObject _settingOpen, _settingClose;
        [SerializeField] GameObject _muteOnButton, _muteOffButton;
        [SerializeField] GameObject _vibrationOnButton, _vibrationOffButton;
        [SerializeField] GameObject _iapButton;
        [SerializeField] GameObject _informationButton;
        [SerializeField] Animator _layoutAnimator;


        int _alphaValue = 0;

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
        }

        public void MuteOffButton()
        {
            _muteOffButton.SetActive(false);
            _muteOnButton.SetActive(true);
        }

        public void VibrationOnButton()
        {
            _vibrationOnButton.SetActive(false);
            _vibrationOffButton.SetActive(true);
        }

        public void VibrationOffButton()
        {
            _vibrationOffButton.SetActive(false);
            _vibrationOnButton.SetActive(true);
        }
    }
}

