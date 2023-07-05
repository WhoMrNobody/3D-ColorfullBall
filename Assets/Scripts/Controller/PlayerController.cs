using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorFullBall.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _speedModifier;

        Touch _touch;
        Rigidbody _rigidbody;
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
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
                        _rigidbody.velocity = new Vector3(_touch.deltaPosition.x * _speedModifier * Time.deltaTime, 
                                                            transform.position.y, 
                                                            _touch.deltaPosition.y * _speedModifier * Time.deltaTime); 
                        break;
                    case TouchPhase.Stationary:

                        break;
                    case TouchPhase.Ended:
                        _rigidbody.velocity = Vector3.zero;
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
