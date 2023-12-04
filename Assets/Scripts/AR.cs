using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : MonoBehaviour, IHandleInput
{
    public GameObject scar;
    public ParticleSystem bulletEffect;
    public ParticleSystem hitEffect;
    public ParticleSystem muzzle;
    private float shootCooldown = 0.05f;
    private float lastShootTime = 0f;
    private bool canShoot = true;
    public CameraManager cameraManager;
    public InvManager invManager;
    // Start is called before the first frame update
    void Start()
    {
        bulletEffect.enableEmission = false;
        muzzle.enableEmission = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100, Color.red);
        handleInput();
        if (!canShoot && Time.time - lastShootTime >= shootCooldown)
        {
            canShoot = true;
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
        {
            if (hit.transform != null)
            {
                Crate c = hit.transform.GetComponent<Crate>();
                Heli h = hit.transform.GetComponent<Heli>();
                if (c != null)
                {
                    c.OnDamaged(10);
                }
                if (h != null)
                {
                    h.OnDamaged(10);
                }
            }
            Vector3 hitPoint = hit.point;
            Vector3 hitNormal = hit.normal;
            SpawnParticleEffect(hitPoint, hitNormal);
        }
    }
    void SpawnParticleEffect(Vector3 position, Vector3 normal)
    {
        ParticleSystem particleSystemInstance = Instantiate(hitEffect, position, Quaternion.identity);
        particleSystemInstance.transform.rotation = Quaternion.LookRotation(normal);
        Destroy(particleSystemInstance.gameObject, 1.5f);
    }

    public void handleInput()
    {
        if (Input.GetButton("Fire1") && canShoot && invManager.pickedUpA)
        {
            muzzle.enableEmission = true;
            bulletEffect.enableEmission = true;
            bulletEffect.Play();
            canShoot = false;
            Shoot();
            lastShootTime = Time.time;
            muzzle.Play();
            cameraManager.ShakeCamera();
        }
    }
}
