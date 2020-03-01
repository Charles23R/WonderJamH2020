using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisable : MonoBehaviour
{
    public Sprite button;
    public Sprite buttonPressed;
    public GameObject[] toDisable;
    // Start is called before the first frame update
    public void onAction()
    {
        for(int i =0; i<toDisable.Length; i++)
        {
            toDisable[i].GetComponent<Collider2D>().enabled = false;
            toDisable[i].GetComponent<SpriteRenderer>().enabled = false;
        }

        this.gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;

    }
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = button;
    }

    public void Reset()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = button;
    }
}
