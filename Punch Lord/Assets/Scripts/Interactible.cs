using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float idleSpeed;
    public float lives;
    public float bounceability;
    public Player player;

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            lives--;
    }
    

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
        this.gameObject.SetActive(false);
    }
}
