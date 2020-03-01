using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keeptrackofthings : MonoBehaviour
{
    public Vector2 velocity;
    public GameObject black;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void saveVelocity()
    {
        velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity;
    }

    IEnumerator FadeIn()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= 0.05f;
            black.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
    }

    IEnumerator applyVelocityRoutine()
    {
        bool looking = true;
        while (looking)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(FadeIn());
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = velocity;
                looking = false;
            }
            yield return null;
        }
        yield return null;
    }

    public void applyVelocity()
    {
        StartCoroutine(applyVelocityRoutine());
    }

    // Update is called once per frame

    void Update()
    {
        black = GameObject.Find("Black");
    }
}
