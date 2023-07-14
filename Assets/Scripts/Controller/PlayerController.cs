using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorFullBall.Managers;
using ColorFullBall.Movements;
using ColorFullBall.UI;

namespace ColorFullBall.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Range(10,50)]
        [SerializeField] float _speedModifier;
        [Range(1, 20)]
        [SerializeField] float _constantSpeed;
        [SerializeField] CameraShake _cameraShake;
        [SerializeField] UIManager _uiManager;
        [SerializeField] GameObject _mainCamera;
        [SerializeField] Transform _topBottom;
        [SerializeField] Transform _bottomBound;
        [SerializeField] GameObject[] _fractures;

        Touch _touch;
        Rigidbody _rigidbody;
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            HandleTransform();

            Debug.Log(GameManager.Instance.GameStatusValue);
        }

        void HandleTransform()
        {   
            if(GameManager.Instance.GameStatusValue == GameManager.GameStatus.Started)
            {
                StartGame();
            }

            if(Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                GameManager.Instance.GameStatusValue = GameManager.GameStatus.Started;

                switch (_touch.phase)
                {
                    case TouchPhase.Began:

                        break;

                    case TouchPhase.Moved:

                        if(GameManager.Instance.GameStatusValue != GameManager.GameStatus.Started) { return; }

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

        void StartGame()
        {
            _uiManager.DisableAllUIElements();
            transform.position += new Vector3(0f, 0f, _constantSpeed * Time.deltaTime);
            _mainCamera.transform.position += new Vector3(0f, 0f, _constantSpeed * Time.deltaTime);
            _topBottom.position += new Vector3(0f, 0f, _constantSpeed * Time.deltaTime);
            _bottomBound.position += new Vector3(0f, 0f, _constantSpeed * Time.deltaTime);
            
        }

        void OnCollisionEnter(Collision hit)
        {
            if (hit.gameObject.CompareTag("Obstacle"))
            {
                gameObject.transform.GetChild(0).transform.gameObject.SetActive(false);

                _cameraShake.CallCameraShake();
                _uiManager.StartCoroutine("FlashDeathEffect");

                foreach (GameObject fractures in _fractures)
                {
                    fractures.GetComponent<SphereCollider>().enabled = true;
                    fractures.GetComponent<Rigidbody>().isKinematic = false;

                    GameManager.Instance.GameStatusValue = GameManager.GameStatus.Failed;
                }
            }
        }
    }

}
