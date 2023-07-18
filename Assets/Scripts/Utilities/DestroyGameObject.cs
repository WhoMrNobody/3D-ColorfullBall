using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorFullBall.Utilities
{
    public class DestroyGameObject : MonoBehaviour
    {
        Vector3 _thisGameVector;

        void Update()
        {

             _thisGameVector.y = transform.position.y;

            if (_thisGameVector.y <= -2f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

