using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FPSController : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float mouseSensitivity = 2.0f;
    public GameObject hand;
    public Transform cameraXDDD;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;
    public HeadBob headBob; 
    public bool isCrouching = false;
    private CharacterController controller;
    private Vector3 oldCrouchHeight = new Vector3(0, -2.1f, 0);
    private Vector3 newCrouchHeight = new Vector3(0, -1.8f, 0);
    private CapsuleCollider capsuleCollider;
    private float gravity = -9;
    private float gravMultiplier = 3;
    private float velocity;
    public GameObject grenadeGO;
    public Transform leftHand;
    public GameObject rightHand;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        HandleMovement();
        HandleCameraRotation();
        CameraFollow();
        ThrowGrenade();
        UpdateHandRotation();
        Crouch();
        Jump();
    }
    private void HandleMovement()
    {
        if (isCrouching)
        {
            moveSpeed = 2.5f;
        }
        else
        {
            moveSpeed = 5;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        velocity += gravity * gravMultiplier * Time.deltaTime;
        moveDirection.y = velocity;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalRotation += mouseX;

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
    }
    private void CameraFollow()
    {
        cameraXDDD.position = transform.position;
        if (headBob != null)
        {
            float speed = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;
            if (speed < 1)
            {
            }
            else
            {
                Vector3 headBobMotion = headBob.FootStepMotion(transform);
                transform.position += headBobMotion;
            }
        }
    }
    private void UpdateHandRotation()
    {
        hand.transform.rotation = Quaternion.Euler(verticalRotation, Camera.main.transform.eulerAngles.y, 0);
    }
    private void Crouch()
    {
        float offset = 0.3f;
        if (Input.GetKeyDown(KeyCode.C) && !isCrouching)
        {
            Debug.Log("Crouch key pressed");
            isCrouching = true;
            capsuleCollider.center = newCrouchHeight;
            transform.localScale -= new Vector3(0, offset, 0);
        }
        if (Input.GetKeyUp(KeyCode.C) && isCrouching)
        {
            Debug.Log("Crouch key released");
            isCrouching = false;
            capsuleCollider.center = oldCrouchHeight;
            transform.localScale += new Vector3(0, offset, 0);
        }
    }
    private void ThrowGrenade()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rightHand.gameObject.SetActive(false);
            StartCoroutine(Delay(1));
            GameObject clone = Instantiate(grenadeGO, leftHand.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(leftHand.forward * 1000f);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity += 20;
        }
    }
    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rightHand.gameObject.SetActive(true);
    }
}
