using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupEffects : MonoBehaviour
{
    public GameObject[] powerups;
    private PlayerController playerControllerScript;
    private MoveForward moveForwardScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveForwardScript = GameObject.FindWithTag("Obstacle").GetComponent<MoveForward>();
    }

    public void Phasing()
    {
        Debug.Log("Picked up PHASING!");
        playerControllerScript.powerupOneRing.gameObject.SetActive(true);
        playerControllerScript.playerRb.detectCollisions = false;
        StartCoroutine(PhasingCountdownRoutine());
    }

    /*
    public void Slowdown()
    {
        Debug.Log("Picked up SLOWDOWN!");
        //playerControllerScript.hasSlowdown = true;
        StartCoroutine(SlowdownCountdownRoutine());
        moveForwardScript.speed -= 10.5f;
    }
    */

    public void NoEnemies()
    {
        Debug.Log("Picked up \"NO ENEMIES!\"");
        playerControllerScript.powerupThreeRing.gameObject.SetActive(true);
        StartCoroutine(NoEnemiesCountdownRoutine());
    }

    IEnumerator PhasingCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        playerControllerScript.playerRb.detectCollisions = true;
        playerControllerScript.powerupOneRing.gameObject.SetActive(false);
        playerControllerScript.hasPhasing = false;
        playerControllerScript.hasPowerUp = false;
        Debug.Log("PHASING over!");
    }

    /*
    IEnumerator SlowdownCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        //moveForwardScript.speed += 3.5f;
        playerControllerScript.hasSlowdown = false;
        playerControllerScript.hasPowerUp = false;
        Debug.Log("SLOWDOWN over!");
    }
    */

    IEnumerator NoEnemiesCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        playerControllerScript.powerupThreeRing.gameObject.SetActive(false);
        playerControllerScript.hasNoEnemies = false;
        playerControllerScript.hasPowerUp = false;
        Debug.Log("\"NO ENEMIES\" over!");
    }
}
