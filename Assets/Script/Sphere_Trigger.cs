using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_Trigger : MonoBehaviour
{
    float destroyTime;

    public float destroyLevel = 1.9f;
    void Start()
    {
        destroyTime = destroyLevel;
    }

    void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
