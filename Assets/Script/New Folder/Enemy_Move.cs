using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public Transform[] movePoints;
    float moveInterval;
    bool isMoving;
    int randnum;
    Vector3 dir;

    void Start()
    {
        moveInterval = 2.0f;
        isMoving = false;
    }

    void Update()
    {
        moveInterval-= Time.deltaTime; 
        if(moveInterval < 0 && !isMoving)
        {
            isMoving = true;
            randnum = Random.Range(0, movePoints.Length);
            dir = movePoints[randnum].position - this.transform.position;
        }

        if (isMoving)
        {
            MovingEnemy();

        }
    }

    void MovingEnemy()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, movePoints[randnum].position, 7.0f * Time.deltaTime);
        //this.transform.LookAt(movePoints[randnum].position);
        this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);

        if (Vector3.Distance(this.transform.position, movePoints[randnum].position) < 0.1f)
        {
            isMoving = false;
            moveInterval = 1.2f;
        }
    }
}
