using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed, divider;
    public bool canJump = true, grounded = true;
    public GameObject hitbox;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            hitbox.SetActive(true);
        } 

    }
    private void FixedUpdate()
    {
        if (rb.velocity.y>0)
            rb.velocity = new Vector2(rb.velocity.x / divider, rb.velocity.y / divider);
        else
            rb.velocity = new Vector2(rb.velocity.x / divider, rb.velocity.y * divider);
    }

    public void Jump()
    {
        grounded = false;
        Vector2 aim = new Vector2(-Input.GetAxisRaw("Horizontal"), -Input.GetAxisRaw("Vertical"));
        rb.velocity = Vector2.zero;
        rb.AddForce(aim.normalized * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!grounded && collision.gameObject.CompareTag("Ground") && Mathf.Abs(rb.velocity.y) < 0.5f)
        {
            grounded = true;
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Interactible") && hitbox.active)
        {
            collision.gameObject.GetComponent<Interactible>().lives--;
            Debug.Log(collision.gameObject.GetComponent<Interactible>().lives);
        }
    }
}
