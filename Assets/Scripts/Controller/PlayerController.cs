using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorFullBall.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _speedModifier;

        Touch _touch;
        void Start()
        {

        }

        void Update()
        {
            HandleTransform();
        }

        void HandleTransform()
        {
            if(Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);

                switch (_touch.phase)
                {
                    case TouchPhase.Began:

                        break;
                    case TouchPhase.Moved:
                        transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * _speedModifier * Time.deltaTime, 
                                                            transform.position.y, 
                                                            transform.position.z + _touch.deltaPosition.y * _speedModifier * Time.deltaTime); 
                        break;
                    case TouchPhase.Stationary:

                        break;
                    case TouchPhase.Ended:

                        break;
                    case TouchPhase.Canceled:

                        break;

                    default:
                        break;
                }
            }
        }
    }

}
