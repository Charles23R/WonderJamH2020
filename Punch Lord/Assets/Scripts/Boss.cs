using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Rigidbody2D rb;
    float startTime, time;
    public float speed,amp,frequence;
    public int cycle;
    Vector2 startPos;
    public Transform transform;
    bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = Time.time - startTime;
        if (time <= cycle*(2*Mathf.PI/frequence))
        {
            if (!reverse)
                rb.MovePosition(new Vector2(startPos.x + time * speed, startPos.y + amp * Mathf.Sin(frequence * time)));
            else if (reverse)
                rb.MovePosition(new Vector2(startPos.x - time * speed, startPos.y + amp * Mathf.Sin(frequence * time)));
        }
        else
        {
            reverse = !reverse;
            startTime = Time.time;
            startPos = transform.position;
        }
    }
}
