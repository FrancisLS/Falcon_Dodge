using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Vector3 lookDirection;
    private GameObject playerBird;

    private Rigidbody bulletRb;
    public float speed;
    public float lifeDuration = 4.0f;   // how long should the projectile last in game.
    private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        playerBird = GameObject.FindWithTag("Player");
        lookDirection = (playerBird.transform.position - transform.position).normalized;
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(lookDirection * speed, ForceMode.Impulse);

        lifeTimer = lifeDuration;   // set countdown timer to lifeDuration.
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy projectile after x amount of time.
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
            Destroy(gameObject);
    }
}
