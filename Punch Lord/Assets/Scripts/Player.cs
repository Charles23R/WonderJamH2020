﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, divider, dashSpeed;
    public bool canJump = true, grounded = true, holdRope = false, grabbing = false, dashUsed = false;
    public Arm hitbox;
    private Vector3 spawnPos;
    public bool isMouse;
    Vector3 mousePos;
    public GameObject portalCD, rope;
    public bool rageBarActive;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && (Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0) && !holdRope)
        {
            if (rageBarActive)
            {
                if (GameObject.FindGameObjectWithTag("RageBar").GetComponent<RageBar>().progress >= 0.25)
                {
                    GameObject.FindGameObjectWithTag("RageBar").GetComponent<RageBar>().progress -= 0.25f;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("RageBar").GetComponent<RageBar>().progress = 0;
                }
            }
            

            isMouse = false;
            hitbox.punch = true;
            IEnumerator Stop()
            {
                yield return new WaitForSeconds(0.05f);
                hitbox.punch = false;
            }
            StartCoroutine(Stop());
        }
        else if ((Input.GetButtonDown("Jump") && isMouse))
        {
            if (rageBarActive)
            {
                if (GameObject.FindGameObjectWithTag("RageBar").GetComponent<RageBar>().progress >= 0.25)
                {
                    GameObject.FindGameObjectWithTag("RageBar").GetComponent<RageBar>().progress -= 0.25f;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("RageBar").GetComponent<RageBar>().progress = 0;
                }
            }

            hitbox.punch = true;
            IEnumerator Stop()
            {
                yield return new WaitForSeconds(0.05f);
                hitbox.punch = false;
            }
            StartCoroutine(Stop());
        }
        if (!holdRope && !dashUsed && Input.GetButtonDown("Dash") && !grounded)
        {
            dashUsed = true;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * dashSpeed);
        }
        if (Input.mousePosition != mousePos && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            isMouse = true;
        }
        mousePos = Input.mousePosition;
        if (!holdRope && Input.GetButtonDown("Grab"))
        {
            grabbing = true;
            IEnumerator Stop()
            {
                yield return new WaitForSeconds(0.05f);
                grabbing = false;
            }
            StartCoroutine(Stop());
        }
        if(holdRope && Input.GetButtonDown("Grab"))
        {
            RotationThing rt = rope.transform.parent.GetComponentInParent<RotationThing>();
            rb.velocity = rope.transform.right * rt.launchSpeed * rt.cosAnswer * (Vector2.Distance(rope.transform.parent.parent.position,rope.transform.position)/rt.maxDistance);
            Destroy(rope);
            holdRope = false;
        }
        if (holdRope) {
            rb.MovePosition(rope.transform.position);
        }
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y>0)
            rb.velocity = new Vector2(rb.velocity.x / divider, rb.velocity.y / divider);
        else
            rb.velocity = new Vector2(rb.velocity.x / divider , rb.velocity.y * divider);
    }

    public void Jump()
    {
        dashUsed = false;
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 aim = new Vector2(0,0);
        Time.timeScale = 1;
        grounded = false;
        if (isMouse)
        {
            aim = new Vector2(-(Input.mousePosition.x - pos.x), -(Input.mousePosition.y - pos.y));
        }
        else
        {
            aim = new Vector2(-Input.GetAxisRaw("Horizontal"), -Input.GetAxisRaw("Vertical"));
        }
        rb.velocity = Vector2.zero;
        rb.AddForce(aim.normalized * speed);
        
    }
    public void Jump(Vector2 aim)
    {
        dashUsed = false;
        grounded = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(aim * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!grounded && collision.gameObject.CompareTag("Ground") && Mathf.Abs(rb.velocity.y) < 0.5f)
        {
            grounded = true;
            canJump = true;
            dashUsed = false;
        }
    }

    public void onDeath()
    {
        GameObject[] toReEnable = GameObject.FindGameObjectsWithTag("Interactible");
        GameObject[] ButtonstoReEnable = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i< toReEnable.Length; i++)
        {
            toReEnable[i].GetComponent<Interactible>().lives = toReEnable[i].GetComponent<Interactible>().initialLives;
            toReEnable[i].SetActive(true);
            toReEnable[i].GetComponent<Collider2D>().enabled = true;
            toReEnable[i].GetComponent<SpriteRenderer>().enabled = true;
        }
        for (int i = 0; i < ButtonstoReEnable.Length; i++)
        {
            ButtonstoReEnable[i].GetComponent<ButtonDisable>().Reset();
        }
        this.transform.position = spawnPos;
    }



}
