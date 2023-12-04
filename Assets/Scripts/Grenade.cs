using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explode;
    private GameObject clone;
    public bool is_destroyed;
    private float timer = 3;
    public bool thrown;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        is_destroyed = false;
        thrown = true;
    }
    void Update()
    {
        RunTimer();
        Explode();
    }
    public void RunTimer()
    {
        if (thrown)
        timer -= Time.deltaTime;
    }
    private void Explode()
    {
        if (timer <= 0)
        {
            is_destroyed = true;
            Destroy(gameObject);
            if (explode != null)
            {
                clone = Instantiate(explode, transform.position, Quaternion.identity);
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
}