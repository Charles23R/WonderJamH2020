using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinIntro : MonoBehaviour
{
    public GameObject goblin;
    public GameObject player;
    public GameObject black;
    public Transform goblindesiredpos;
    public GameObject textbox1, textbox2;
    goblinmovement gmov;
    // Start is called before the first frame update
    void Start()
    {
        gmov = goblin.GetComponent<goblinmovement>();
        StartCoroutine(GoblinEscape());
    }

    IEnumerator GoblinEscape()
    {
        black.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        goblin.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(0.5f);
        gmov.Jump();
        while(goblin.transform.position.x < goblindesiredpos.transform.position.x)
        {
            gmov.goRight();
            yield return null;
        }
        yield return null;
        StartCoroutine(Beginning());
    }

    IEnumerator Beginning()
    {
        textbox1.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        textbox1.SetActive(false);
        yield return new WaitForSeconds(1f);
        textbox2.SetActive(true);
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        textbox2.SetActive(false);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
