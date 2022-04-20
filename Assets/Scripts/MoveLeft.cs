using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Variables
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        // The 'Find'method locates the game object called 'Player' and then accesses the PlayerController script which is a component of said object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        // Since the 'PlayerController' component (located in the 'Player' GameObject) was stored in a variable, its data can now be accessed. In this case, the 'gameOver' variable
        {
            // Constantly move obstacles to the left if the game is not over
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x > leftBound && gameObject.CompareTag("Obstacle"))
        // Destroy obstacles when out of bounds
        {
            Destroy(gameObject);
        }
    }
}
