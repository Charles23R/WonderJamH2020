using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisable : MonoBehaviour
{
    public GameObject toDisable;
    // Start is called before the first frame update
    public void onAction()
    {
        toDisable.GetComponent<Collider2D>().enabled = false;
        toDisable.GetComponent<SpriteRenderer>().enabled = false;
    }
}
