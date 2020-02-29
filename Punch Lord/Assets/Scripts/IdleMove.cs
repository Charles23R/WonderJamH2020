using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMove : MonoBehaviour
{

    public int translateX, translateY;
    public Interactible inter;
    public float moveTime;
    // Start is called before the first frame update
    void Start()
    {
        //StartMove();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.position + new Vector3(translateX, translateY, 0) * moveTime * Time.deltaTime);
    }

    /*
    IEnumerator StartMove()
    {

        yield return new WaitForSeconds(1);
        //MoveToTarget(this.transform.position + new Vector3(-translateX, -translateY, 0));
        transform.Translate((transform.position + new Vector3(translateX, translateY, 0))*Time.deltaTime);
    }

    IEnumerator StartMoveRight()
    {
        yield return new WaitForSeconds(1);
        MoveToTarget(this.transform.position + new Vector3(translateX,translateY,0));
    }

    void MoveToTarget(Vector3 targetPosition)
    {
        Vector3 currentPosition = this.transform.position;
        
            Vector3 directionOfTravel = targetPosition - currentPosition;
            directionOfTravel.Normalize();
            this.transform.Translate(
                            (directionOfTravel.x * inter.idleSpeed * Time.deltaTime),
                            (directionOfTravel.y * inter.idleSpeed * Time.deltaTime),
                            (directionOfTravel.z * inter.idleSpeed * Time.deltaTime),
                            Space.World);
    }
    */
}
