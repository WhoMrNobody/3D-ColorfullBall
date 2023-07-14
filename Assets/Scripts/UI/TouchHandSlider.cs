using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandSlider : MonoBehaviour
{
    [SerializeField] Vector3 _startPos, _lastPos;
    [SerializeField] float _sliderSpeed;
    void Update()
    {
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(_startPos, _lastPos, Mathf.PingPong(Time.time * _sliderSpeed, 1f));
    }
}
