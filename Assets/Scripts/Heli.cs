using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli : MonoBehaviour
{
    public List<Transform> waypoints;
    private float moveSpeed = 10f;
    private float rotationSpeed = 5f;
    private int health = 100;
    public Rigidbody rb;
    public Spin spin;
    public GameObject explode;
    private bool hasExploded = false;
    public void OnDamaged(int damage)
    {
        health -= damage;
        if (health <= 0) currentState = HeliState.Dead;
    }

    private void Destroy()
    {
        if (!hasExploded)
        {
            rb.useGravity = true;
            spin.enabled = false;
            GameObject clone = Instantiate(explode, transform.position, transform.rotation);
            Destroy(clone, 2f);
            hasExploded = true; 
        }
    }
    private enum HeliState
    {
        Moving,
        Rotating,
        Dead
    }
    private HeliState currentState = HeliState.Moving;
    private int currentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case HeliState.Moving:
                MoveTowardsWaypoint();
                break;
            case HeliState.Rotating:
                RotateTowardsWaypoint();
                break;
            case HeliState.Dead:
                Destroy();
                break;
            default:
                break;
        }
    }

    void MoveTowardsWaypoint()
    {
        if (waypoints.Count == 0)
        {
            return; 
        }

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentState = HeliState.Rotating;
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }

    void RotateTowardsWaypoint()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 directionToWaypoint = targetWaypoint.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, rotation) < 1f)
        {
            currentState = HeliState.Moving;
        }
    }
}
