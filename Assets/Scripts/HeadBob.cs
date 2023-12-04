using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    private bool _enable = true;
    [SerializeField, Range(0, 0.1f)] 
    private float _Amplitude = 0.01f;
    [SerializeField, Range(0, 30)] 
    private float _frequency = 10.0f;
    public Transform _camera = null;
    public Transform player;
    public Transform anchor = null;
    private Vector3 _startPos;
    public CharacterController _controller;

    private void Awake()
    {
        _startPos = _camera.localPosition;
    }

    void Update()
    {
        if (player != null)
        if (!_enable) return;
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }
    public Vector3 FootStepMotion(Transform target)
    {
        Vector3 localMotion = new Vector3(
            Mathf.Cos(Time.time * _frequency / 2) * _Amplitude * 2,
            Mathf.Sin(Time.time * _frequency) * _Amplitude,
            0
        ); 
        Vector3 worldMotion = target.rotation * localMotion;
        return worldMotion;
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + anchor.localPosition.y, transform.position.z);
        pos += anchor.forward * 15.0f;
        return pos;
    }
    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }
}