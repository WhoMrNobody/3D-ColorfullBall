using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorFullBall.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Image _whiteImage;
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
    }
}

