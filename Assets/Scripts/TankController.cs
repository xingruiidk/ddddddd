using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    public float rotateSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");
        Vector3 rotateTorque = Vector3.up * rotateInput * rotateSpeed;
        rb.AddTorque(rotateTorque);
        Vector3 moveForce = transform.right * moveInput * moveSpeed;
        rb.AddForce(moveForce);
    }
}
