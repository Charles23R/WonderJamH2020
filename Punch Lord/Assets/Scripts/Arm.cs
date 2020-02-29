using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Vector2 aim = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float angle = Mathf.Atan2(-aim.y, -aim.x) * Mathf.Rad2Deg; ;
        transform.eulerAngles = new Vector3(0, 0, angle-90);
        IEnumerator Reset()
        {
            yield return new WaitForSeconds(0.15f);
            gameObject.SetActive(false);
        }
        StartCoroutine(Reset());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<Player>().Jump();
    }

}
