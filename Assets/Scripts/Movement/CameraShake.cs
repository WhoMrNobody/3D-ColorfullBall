using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorFullBall.Movements
{
    public class CameraShake : MonoBehaviour
    {   
        bool _isShaked = false;
        IEnumerator CameraShakes(float duration, float magnitute)
        {
            Vector3 originalPos = transform.localPosition;

            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitute;
                float y = Random.Range(-1f, 1f) * magnitute;

                transform.localPosition = new Vector3(x, y, originalPos.z);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localPosition = originalPos;
        }

        public void CallCameraShake()
        {   
            if(!_isShaked)
            {
                StartCoroutine(CameraShakes(0.10f, 0.3f));
                _isShaked=true;
            }
            
        }
    }
}

