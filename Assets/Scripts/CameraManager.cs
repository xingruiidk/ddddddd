using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 _currentOrientation;
    private Vector3 _targetOrientation;
    private float recoilX;
    private float recoilY;
    private float recoilZ;
    private float snapRate;
    private float returnSpeed;
    private void Start()
    {
        recoilX = -2f;
        recoilY = 3f;
        recoilZ = 0;
        snapRate = 100;
        returnSpeed = 100f;
        _currentOrientation = new Vector3(0f, 90f, 0f);
    }

    private void Update()
    {
        _targetOrientation = Vector3.Lerp(_targetOrientation, Vector3.zero, returnSpeed * Time.deltaTime);
        _currentOrientation = Vector3.Slerp(_currentOrientation, _targetOrientation, snapRate * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(_currentOrientation);
        //Debug.Log(_currentOrientation);
    }
   
    public void ShakeCamera()
    {
        _targetOrientation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
}
