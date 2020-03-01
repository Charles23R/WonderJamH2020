using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poing : MonoBehaviour
{
    public GameObject main;
    public Transform target;
    public float speed;
    public Sprite spriteNeutral;
    public Animator animator;
    public Vector3 start;
    public bool move;
    float t;

    public void onPunch()
    {
        move = false;
        transform.position = start;
        IEnumerator Stop()
        {
            yield return new WaitForSeconds(0.5009f);
            animator.Play("poingStill");
            move = false;
            transform.position = start;
        }
        StopCoroutine(Stop());
        animator.Play("poingStill");
        animator.Play("frapper");
        StartCoroutine(Stop());
        start = transform.position;
        move = true;
        //animator.SetBool("isAttacking", true);
        //StartCoroutine(animPoing());

    }

    private void Update()
    {
        if (move)
        {
            transform.position += Vector3.Lerp(start, target.position, t);
            t += 1f * Time.deltaTime;
        }

    }


}
