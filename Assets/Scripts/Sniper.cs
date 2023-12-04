using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Sniper : MonoBehaviour, IHandleInput
{
    public GameObject AWM;
    public ParticleSystem bulletEffect;
    public ParticleSystem hitEffect;
    public ParticleSystem muzzle;
    private float shootCooldown = 1f;
    private float lastShootTime = 0f;
    private bool canShoot = true;
    public CameraManager cameraManager;
    public InvManager invManager;
    public Image inv;
    public Image Xhair;
    public Image Scoped; 
    private float transitionDuration = 0.2f;
    private bool isTransitioning = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    public MeshRenderer[] awmMeshRenderers;
    // Start is called before the first frame update
    void Start()
    {
        bulletEffect.enableEmission = false;
        muzzle.enableEmission = false;
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
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
        {
            if (hit.transform != null)
            {
                Crate c = hit.transform.GetComponent<Crate>();
                Heli h = hit.transform.GetComponent<Heli>();
                if (c != null)
                {
                    c.OnDamaged(100);
                }
                if (h != null)
                {
                    h.OnDamaged(100);
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
        if (Input.GetButtonDown("Fire1") && canShoot && invManager.pickedUpS)
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
        if (Input.GetButton("Fire2") && invManager.pickedUpS)
        {
            if (!isTransitioning)
            {
                StartCoroutine(MoveAWM(new Vector3(-0.65f, 0.25f, -0.75f), () =>
                {
                    ToggleMeshRenderers(false);
                    inv.gameObject.SetActive(false);
                    Xhair.gameObject.SetActive(false);
                    Scoped.gameObject.SetActive(true);
                }));
            }
        }
        else if (!Input.GetButton("Fire2") && invManager.pickedUpS)
        {
            if (!isTransitioning)
            {
                ToggleMeshRenderers(true);
                inv.gameObject.SetActive(true);
                Xhair.gameObject.SetActive(true);
                Scoped.gameObject.SetActive(false);
                StartCoroutine(MoveAWM(new Vector3(-0.14f, 0.06f, -0.35f), () =>
                {
                }));
            }
        }
        IEnumerator MoveAWM(Vector3 targetPos, Action onMoveComplete)
        {
            isTransitioning = true;
            initialPosition = AWM.transform.localPosition;
            targetPosition = targetPos;
            float elapsedTime = 0f;
            while (elapsedTime < transitionDuration)
            {
                AWM.transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / transitionDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            AWM.transform.localPosition = targetPosition;
            isTransitioning = false;
            onMoveComplete?.Invoke();
        }
        void ToggleMeshRenderers(bool enable)
        {
            for (int i = 0; i < awmMeshRenderers.Length; i++)
            {
                awmMeshRenderers[i].enabled = enable;
            }
        }
    }
}
