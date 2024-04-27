using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public Transform[] movePoints;
    float moveInterval;
    bool isMoving;
    int randnum;

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

        }

        if (isMoving)
        {
            MovingEnemy();

        }
    }

    void MovingEnemy()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, movePoints[randnum].position, 5.0f * Time.deltaTime);
        this.transform.LookAt(movePoints[randnum].position);
        if(Vector3.Distance(this.transform.position, movePoints[randnum].position) < 0.1f)
        {
            isMoving = false;
            moveInterval = 1.5f;
        }
    }
}
