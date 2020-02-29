using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float idleSpeed;
    public float lives;
    public float bounceability;
    public Player player;
    public bool respawnable;
    public float timeBeforeRespawn;
    public float initialLives;

    // Update is called once per frame
    void Start()
    {
        initialLives = lives;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        /*
        if (other.gameObject.GetComponent<Arm>().punch)
        {
            other.gameObject.GetComponent<Arm>().punch = false;
            lives--;
        }
        */
    }
    

    private void FixedUpdate()
    {
        if (lives == 0)
        {
            DisableInstance();
        }
    }

    public void DisableInstance()
    {
        // Removes this script instance from the game object
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (respawnable)
        {
            StartCoroutine(RespawnCoroutine());
        }
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(timeBeforeRespawn);
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return null;
    }
}
