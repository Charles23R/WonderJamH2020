using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float idleSpeed;
    public float lives;
    public float bounceability;
    //public Player player;

    // Update is called once per frame
    void Update()
    {
       
    }

    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        if (player.isAttacking())
        {
            lives--;
        }
    }
    */

    private void FixedUpdate()
    {
        if (lives == 0)
        {
            DisableInstance();
        }
    }

    void DisableInstance()
    {
        // Removes this script instance from the game object
        this.enabled = false;
    }
}
