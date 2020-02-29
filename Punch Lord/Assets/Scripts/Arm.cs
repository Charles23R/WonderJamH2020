using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public bool punch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Vector2 aim = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            float angle = Mathf.Atan2(-aim.y, -aim.x) * Mathf.Rad2Deg; ;
            transform.eulerAngles = new Vector3(0, 0, angle - 90);
        }

        else if (this.gameObject.GetComponentInParent<Player>().isMouse)
        {
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 aim = new Vector2(Input.mousePosition.x - pos.x, Input.mousePosition.y - pos.y);
            float angle = Mathf.Atan2(-aim.y, -aim.x) * Mathf.Rad2Deg; ;
            transform.eulerAngles = new Vector3(0, 0, angle - 90);
        }


    }

    private void OnEnable()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (punch&& !collision.gameObject.CompareTag("Vent") && !collision.gameObject.CompareTag("TimeZone"))
        {
            GetComponentInParent<Player>().Jump();
            if (collision.gameObject.CompareTag("Interactible"))
            {
                collision.gameObject.GetComponent<Interactible>().lives--;
                
            }
            if (collision.gameObject.CompareTag("Button"))
            {
                collision.gameObject.GetComponent<ButtonDisable>().onAction();
                collision.gameObject.GetComponent<Interactible>().lives--;
            }
            punch = false;
        }
    }
}
