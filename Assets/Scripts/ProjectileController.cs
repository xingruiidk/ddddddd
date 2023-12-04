using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float timeToLive = 3f;
    public GameObject explode;
    private float destroyTime;
    public HomingRocket homingRocket;
    public RPGRocket rpgRocket;
    void Start()
    {
        destroyTime = Time.time + timeToLive;
    }

    void Update()
    {
        if (!homingRocket.is_destroyed)
        {
            if (Time.time >= destroyTime)
            {
                Destroy(gameObject);
                GameObject clone = Instantiate(explode, transform.position, Quaternion.identity);
                Destroy(clone, 2);
            }
        }
        if (!rpgRocket.is_destroyed)
        {
            if (Time.time >= destroyTime)
            {
                Destroy(gameObject);
                GameObject clone = Instantiate(explode, transform.position, Quaternion.identity);
                Destroy(clone, 2);
            }
        }
    }
}
