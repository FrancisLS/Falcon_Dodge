using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed = 5.0f;

    private GameObject playerBird;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerBird = GameObject.FindWithTag("Player");
        playerControllerScript = playerBird.GetComponent<PlayerController>();

        //InvokeRepeating("ShootProjectile", 1.2f, 2.3f);
        Invoke("ShootProjectile", 1.2f);
        Invoke("ShootProjectile", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate enemy towards the player for aiming projectiles.
        transform.LookAt(playerBird.transform);
        Debug.DrawRay(transform.position, playerBird.transform.position - transform.position, Color.red);
    }


    void ShootProjectile()
    {
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0, 0, -1), transform.rotation);
        }
    }

    /*
    private float yRotationClamp()
    {
        float yRotation = transform.rotation.y;
        float yPosLimit = Mathf.Clamp(yRotation, -90, 90);
        return yPosLimit;
    }
    */
}
