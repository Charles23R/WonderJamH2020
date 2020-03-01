using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poing : MonoBehaviour
{
    
    public GameObject main;
    public Vector3 target;
    public float speed;
    public Sprite spriteNeutral;
    public Animator animator;


    public void onPunch()
    {
        animator.SetBool("isAttacking", true);
        StartCoroutine(animPoing());

    }

    IEnumerator animPoing()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        yield return null;
    }

    private void Update()
    {
        target = main.transform.position;
    }

    public void StopAnim()
    {
        StopCoroutine(animPoing());
        animator.SetBool("isAttacking", false);
    }
    
}
