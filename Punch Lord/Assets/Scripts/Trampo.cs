using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampo : MonoBehaviour
{

    public float bouncy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().Jump(new Vector2(0, bouncy));
        this.gameObject.GetComponent<Interactible>().DisableInstance();
    }
}
