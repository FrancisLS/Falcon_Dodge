using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 8.5f;
    private float outOfBoundsZ = -30.0f;
    private float outOfBoundsY = 20.0f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver == false)
        {
            // used Space.World to use world coordinates for movement since some objects are rotated
            if (gameObject.CompareTag("Enemy") || gameObject.CompareTag("Powerup") || gameObject.CompareTag("Obstacle"))
                transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        }
        
        // destroy gameObject if they're way out of sight.
        if (transform.position.z < outOfBoundsZ || transform.position.y > outOfBoundsY || transform.position.y < -outOfBoundsY)
            Destroy(gameObject);
    }
}
