using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour
{
    public GameObject explode;
    private Renderer rocketRenderer;
    private Collider rocketCollider;
    private ParticleSystem rocketParticle;
    private GameObject clone;
    public bool is_destroyed;
    public SphereCast sphereCast;
    private Transform target;
    private float rotate;
    private float rotationSpeed = 10f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        is_destroyed = false;
        rocketCollider = GetComponent<Collider>();
        rocketRenderer = GetComponent<Renderer>();
        rocketParticle = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        target = sphereCast.FindClosestObject();
        if (target != null && !is_destroyed)
        {
            Vector3 directionToTarget = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        is_destroyed = true;
        Destroy(gameObject);
        if (explode != null)
        {
            clone = Instantiate(explode, collision.contacts[0].point, Quaternion.identity);
        }
        var surroundingObjects = Physics.OverlapSphere(transform.position, 5);
        foreach (var obj in surroundingObjects)
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (rb == null) continue;
            rb.AddExplosionForce(50, transform.position, 5);
            var c = obj.GetComponent<Crate>();
            if (c != null)
            {
                c.OnDamaged(100);
            }
            var h = obj.GetComponent<Heli>();
            if (h != null)
            {
                h.OnDamaged(100);
            }
        }
        Destroy(clone, 2);
    }
}