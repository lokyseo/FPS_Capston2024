using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMark_Destroy : MonoBehaviour
{
    float destroyTime;
    void Start()
    {
        destroyTime = 3.0f;


    }

    void Update()
    {
        destroyTime -= Time.deltaTime;
        if(destroyTime < 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
