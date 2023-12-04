using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class RPGLauncher : MonoBehaviour, IHandleInput
{
    public GameObject RPG;
    private float shootCooldown = 2f;
    private float lastShootTime = 0f;
    private bool canShoot = true;
    public InvManager invManager;
    public CameraManager cameraManager;
    public GameObject rocket;
    private GameObject rocketv2;
    public GameObject explode;
    public Transform tip;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        handleInput();
        if (!canShoot && Time.time - lastShootTime >= shootCooldown)
        {
            canShoot = true;
        }
    }
    private void Shoot()
    {
        Vector3 spawnPosition = tip.position + tip.forward * 2;
        rocketv2 = Instantiate(rocket, spawnPosition, tip.rotation * Quaternion.Euler(-90, 0, 0));
        rocketv2.GetComponent<Rigidbody>().AddForce(tip.forward * 4000f);
    }
    public void handleInput()
    {
        if (Input.GetButtonDown("Fire1") && canShoot && invManager.pickedUpR)
        {
            canShoot = false;
            Shoot();
            lastShootTime = Time.time;
            cameraManager.ShakeCamera();
        }
    }
}
