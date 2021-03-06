﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class falling : MonoBehaviour
{
    public GameObject black;
    public GameObject desiredPosition;
    public GameObject player;
    public GameObject sewerHole;

    IEnumerator Falling()
    {
        yield return new WaitForSeconds(0.5f);
        black.SetActive(false);
        while (player.transform.position.y > desiredPosition.transform.position.y)
        {
            player.transform.position -= new Vector3(0, 3.5f * Time.deltaTime, 0);
            sewerHole.transform.position += new Vector3(0, 10.5f * Time.deltaTime, 0);
            yield return null;
        }
        black.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(3);
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Falling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
