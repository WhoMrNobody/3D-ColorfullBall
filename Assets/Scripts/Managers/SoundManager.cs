using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorFullBall.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [SerializeField] private AudioClip _buttonClip,_blowUpClip, _cashClip, _completeClip, _objectHitClip;
        [SerializeField] private AudioSource _buttonAudioSource, _blowUpAudioSource, _cashAudioSource, _completeAudioSource, _objectHitAudioSource;
        
        public void ButtonSound()
        {
            _buttonAudioSource.PlayOneShot(_buttonClip);
        }

        public void BlowUpSound()
        {
            _blowUpAudioSource.PlayOneShot(_blowUpClip, 0.4f);    
        }

        public void CashSound()
        {
            _cashAudioSource.PlayOneShot(_cashClip);
        }

        public void CompleteSound()
        {
            _completeAudioSource.PlayOneShot(_completeClip);
        }

        public void ObjectHitSound()
        {
            _objectHitAudioSource.PlayOneShot(_objectHitClip);
        }


    }

}
