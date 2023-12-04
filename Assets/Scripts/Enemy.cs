using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 1f; 
    private Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the tag 'Player'.");
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();
            rb.velocity = directionToPlayer * speed;
        }
    }
}
