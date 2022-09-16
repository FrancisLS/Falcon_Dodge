using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    private GameObject randObstacle;
    private GameObject enemy;
    private GameObject powerup;

    private float startDelay = 5;
    private float startRate = 6;

    private Vector3 obstacleSpawnPos = new Vector3(0, (float)11.5, 37+11);
    private Vector3 randSpawnPos;
    private float spawnPosX;
    private float spawnPosY;
    private float spawnPosZ;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SpawnObstacle();
        SpawnEnemyAndPowerup();
        InvokeRepeating("SpawnObstacle", startDelay, startRate);
        InvokeRepeating("SpawnEnemyAndPowerup", startDelay, startRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.isGameOver == false)
        {
            randObstacle = obstaclePrefab[Random.Range(0, 12)];
            Instantiate(randObstacle, obstacleSpawnPos, randObstacle.transform.rotation);
        }
    }

    void SpawnEnemyAndPowerup()
    {
        if (playerControllerScript.isGameOver == false)
        {
            if (playerControllerScript.hasNoEnemies == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    enemy = enemyPrefab[Random.Range(0, 2)];
                    Instantiate(enemy, genRandomPos(), enemy.transform.rotation);
                }
            }

            if (playerControllerScript.hasPowerUp == false)
            {
                powerup = powerupPrefab[Random.Range(0,2)];
                Instantiate(powerup, genRandomPos(), powerup.transform.rotation);
            }
        }
    }

    // generates random Vector3 for enemy/powerup spawn position
    Vector3 genRandomPos()
    {
        spawnPosX = Random.Range(-26, 26);
        spawnPosY = Random.Range(3, 22);
        spawnPosZ = Random.Range(4+30, 36+6);
        randSpawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return randSpawnPos;
    }
}
