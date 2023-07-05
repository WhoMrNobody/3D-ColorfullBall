using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorFullBall.Movements
{
    public class WorldBounds : MonoBehaviour
    {
        [SerializeField] Transform _vectorTop;
        [SerializeField] Transform _vectorBottom;
        [SerializeField] Transform _vectorLeft;
        [SerializeField] Transform _vectorRight;

        void LateUpdate()
        {
            HandleWorldBounds();
        }

        void HandleWorldBounds()
        {
            Vector3 viewPos = transform.position;
            viewPos.z = Mathf.Clamp(viewPos.z, _vectorBottom.position.z, _vectorTop.position.z);
            viewPos.x = Mathf.Clamp(viewPos.x, _vectorLeft.position.x, _vectorRight.position.x);
            transform.position = viewPos;
        }
    }
}

