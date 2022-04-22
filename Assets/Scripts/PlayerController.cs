using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpforce;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trigger");
            // Inside Unity: Animator (Controller) > Layer > Jumping --> Click the arrow that goes from 'Run' to 'Running_Jump', then under 'Conditions' check the name of the trigger
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        // Checks for a collision event and then checks if the collided object has a specific tag name
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true); // Animation condition: 'Death_b' parameter for death animation must be true
            playerAnim.SetInteger("DeathType_int", 1); // Animation condition: set the Condition of death animation to number 1 (the animation is called Death_01)
        }
    }
}
