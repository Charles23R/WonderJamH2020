using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poing : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public Vector3 start;

    public void onPunch()
    {
        start = gameObject.transform.position;
        StopCoroutine(Stop());
        animator.Play("poingStill");
        animator.Play("frapper");
        StartCoroutine(Stop());
        start = transform.position;
        //animator.SetBool("isAttacking", true);
        //StartCoroutine(animPoing());

    }

    IEnumerator Stop()
    {
        while (gameObject.transform.position.y < GameObject.Find("HitBox").transform.position.y + GameObject.Find("HitBox").GetComponent<CapsuleCollider2D>().size.y)
        {
            Vector2 aim = new Vector2(Input.mousePosition.x - transform.position.x, Input.mousePosition.y - transform.position.y);
            float angle = Mathf.Atan2(-aim.y, -aim.x) * Mathf.Rad2Deg;
            Debug.Log("hello");
            gameObject.transform.position = new Vector2(gameObject.transform.position.y + speed, gameObject.transform.position.x);
        }
        yield return new WaitForSeconds(0.5009f);
        animator.Play("poingStill");

        gameObject.transform.position = start;
    }

    private void Update()
    {
        /*if (move)
        {
            transform.position += Vector3.Lerp(start, target.position, t);
            t += 1f * Time.deltaTime;
        }*/

    }


}
