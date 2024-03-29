using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_Trigger : MonoBehaviour
{
    float destroyTime;
    void Start()
    {
        destroyTime = 1.9f;
    }

    void Update()
    {
        destroyTime-= Time.deltaTime; 
        if ( destroyTime < 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
