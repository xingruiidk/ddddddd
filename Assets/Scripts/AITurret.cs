using UnityEngine;

public class AITurret : MonoBehaviour
{
    private float rotationSpeed = 5f;
    private Transform playerTransform;
    private bool detect = false;
    public Transform tip;
    public ParticleSystem bulletEffect;
    public ParticleSystem muzzle;
    private float shootCooldown = 0.5f;
    private float lastShootTime = 0f;
    private bool canShoot = true;
    private void Update()
    {
        if (!canShoot && Time.time - lastShootTime >= shootCooldown)
        {
            canShoot = true;
        }
        ShootRaycast();
        ShootPlayer();
        RotateTurret();
        
    }

    void RotateTurret()
    {
        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            Quaternion yOnlyRotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, yOnlyRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void ShootRaycast()
    {
        if (playerTransform != null)
        {
            Vector3 raycastOrigin = tip.position;
            Ray ray = new Ray(raycastOrigin, transform.forward);
            float raycastDistance = 5f;

            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    detect = true;
                }
                else
                {
                    detect = false;
                }
            }
            else
            {
                detect = false;
            }
        }
    }
    private void ShootPlayer()
    {
        if (detect && canShoot)
        {
            lastShootTime = Time.time;
            muzzle.enableEmission = true;
            bulletEffect.enableEmission = true;
            bulletEffect.Play();
            muzzle.Play();
            canShoot = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = null;
        }
    }
}
