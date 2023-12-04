using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGRocket : MonoBehaviour
{
    public GameObject explode;
    private GameObject clone;
    public bool is_destroyed;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        is_destroyed = false;
    }
    void Update()
    {
        // You can add any behavior here that you want to happen continually in each frame
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
            var h = obj.GetComponent<Heli>();
            if (h != null)
            {
                h.OnDamaged(100);
            }
            var c = obj.GetComponent<Crate>();
            if (c != null)
            {
                c.OnDamaged(100);
            }
        }
        Destroy(clone, 2);
    }
}