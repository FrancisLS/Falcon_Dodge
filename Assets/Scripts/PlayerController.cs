using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    //public float forwardSpeed = 3.0f;
    public float horizSpeed = 10.0f;
    public float maxVertSpeed = 15.0f;  // for limiting vertical-speed if too much jumpForce applied
    public float jumpForce = 10.0f;
    private float yLimitForce = 0.5f;   // force applied when player hits yRangeLimit
    private float horizInput;
    private float xRangeLimit = 27.0f, yRangeLimit = 23.0f;

    public GameObject powerupOneRing;
    public GameObject powerupThreeRing;
    public bool hasPowerUp;
    public bool hasPhasing;
    public bool hasSlowdown;
    public bool hasNoEnemies;

    public bool isGameOver = false;

    private PowerupEffects powerupEffects;

    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
        powerupEffects = GetComponent<PowerupEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        // move sideways using addForce
        horizInput = Input.GetAxis("Horizontal");
        if (isGameOver == false)
        {
            Vector3 movement = new Vector3(horizInput, 0, 0);
            playerRb.AddForce(movement * horizSpeed, ForceMode.Acceleration);
        }

        // limits vertical speed for when player spams spacebar
        playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, maxVertSpeed);

        // adds jumpForce (upward)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // stop horizontal movement at x-range limit
        if (transform.position.x > xRangeLimit)
            transform.position = new Vector3(xRangeLimit, transform.position.y, transform.position.z);
        if (transform.position.x < -xRangeLimit)
            transform.position = new Vector3(-xRangeLimit, transform.position.y, transform.position.z);

        // stop vertical movement at y-range limit
        if (transform.position.y > yRangeLimit)
            playerRb.AddForce(Vector3.down * yLimitForce, ForceMode.Impulse);
        if (transform.position.y < 0.9 && isGameOver==false)   // -y border is at 0.9
            playerRb.AddForce(Vector3.up * yLimitForce, ForceMode.Impulse);

        powerupOneRing.transform.position = transform.position + new Vector3(0, 2.3f, 0);
        powerupThreeRing.transform.position = transform.position + new Vector3(0, 2.3f, 0);
    }

    // When player hits either obstacle, projectile or enemies. Stop spawn, movement, and game over.
    // When player hits powerup, destroy powerup and grant effects.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            Debug.Log("Game over!");
        }

        if (collision.gameObject.name.Equals("Powerup - Phasing(Clone)"))
        {
            hasPowerUp = true;
            hasPhasing = true;
            powerupEffects.Phasing();
            Destroy(collision.gameObject);
        }
            
        /*
        if (collision.gameObject.name.Equals("Powerup 2 - Slowdown(Clone)"))
        {
            hasPowerUp = true;
            hasSlowdown = true;
            powerupEffects.Slowdown();
            Destroy(collision.gameObject);
        }
        */
            
        if (collision.gameObject.name.Equals("Powerup 3 - No enemies(Clone)"))
        {
            hasPowerUp = true;
            hasNoEnemies = true;
            powerupEffects.NoEnemies();
            Destroy(collision.gameObject);
        }
    }
}
