using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public float progress;
    public float speed;
    bool firstPunch;
    // Start is called before the first frame update
    void Start()
    {
        progress = 0;
        firstPunch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstPunch)
        {
            progress += (speed * Time.deltaTime);
            this.gameObject.GetComponent<Slider>().value = progress;
            if(progress >= 1)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().onDeath();
                progress = 0;
            }
        }
            
    }

    public void onPunch()
    {
        firstPunch = true;
    }
}
