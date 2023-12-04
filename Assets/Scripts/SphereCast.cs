using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public Transform FindClosestObject()
    {
        float lockRadius = 10f;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit[] hits = Physics.SphereCastAll(ray, lockRadius, 100, enemyLayer);

        Debug.Log("Number of hits: " + hits.Length);

        Transform closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (RaycastHit hit in hits)
        {
            float distance = Vector3.Distance(transform.position, hit.transform.position);
            Debug.Log("Distance to enemy: " + distance);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = hit.transform;
            }
            Debug.DrawRay(transform.position, Camera.main.transform.forward * 10f, Color.red);
        }

        return closestEnemy;
    }

}
