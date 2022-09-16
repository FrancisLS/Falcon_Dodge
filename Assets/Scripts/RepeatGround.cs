using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    public float speed = 8.5f;
    private float outOfBoundsZ = -300.0f;
    private Vector3 startPos;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
            if (transform.position.z < outOfBoundsZ)
                transform.position = startPos;
        }
    }
}
